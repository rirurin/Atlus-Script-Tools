﻿using System;
using System.IO;
using System.Reflection;
using System.Text;
using AtlusScriptLibrary.Common.Logging;
using AtlusScriptLibrary.Common.Libraries;
using AtlusScriptLibrary.Common.Text;
using AtlusScriptLibrary.Common.Text.Encodings;
using AtlusScriptLibrary.FlowScriptLanguage;
using AtlusScriptLibrary.FlowScriptLanguage.BinaryModel;
using AtlusScriptLibrary.FlowScriptLanguage.Compiler;
using AtlusScriptLibrary.FlowScriptLanguage.Decompiler;
using AtlusScriptLibrary.FlowScriptLanguage.Disassembler;
using AtlusScriptLibrary.MessageScriptLanguage;
using AtlusScriptLibrary.MessageScriptLanguage.Compiler;
using AtlusScriptLibrary.MessageScriptLanguage.Decompiler;
using FormatVersion = AtlusScriptLibrary.FlowScriptLanguage.FormatVersion;
using System.Diagnostics;

namespace AtlusScriptCompiler
{
    internal class Program
    {
        public static AssemblyName AssemblyName = Assembly.GetExecutingAssembly().GetName();
        public static Version Version = AssemblyName.Version;
        public static Logger Logger = new Logger(nameof(AtlusScriptCompiler));
        public static LogListener Listener = new FileAndConsoleLogListener(true, LogLevel.Info | LogLevel.Warning | LogLevel.Error | LogLevel.Fatal);
        public static string InputFilePath;
        public static string OutputFilePath;
        public static bool IsActionAssigned;
        public static bool DoCompile;
        public static bool DoDecompile;
        public static bool DoDisassemble;
        public static InputFileFormat InputFileFormat;
        public static OutputFileFormat OutputFileFormat;
        public static string MessageScriptTextEncodingName;
        public static Encoding MessageScriptEncoding;
        public static string LibraryName;
        public static bool LogTrace;
        public static bool FlowScriptEnableProcedureTracing;
        public static bool FlowScriptEnableProcedureCallTracing;
        public static bool FlowScriptEnableFunctionCallTracing;
        public static bool FlowScriptEnableStackCookie;
        public static bool FlowScriptEnableProcedureHook;
        public static bool UEWrapped;
        public static string UEPatchFile;

        public static bool FlowScriptSumBits { get; private set; }

        public static bool FlowScriptOverwriteMessages { get; private set; }

        private static void DisplayUsage()
        {
            Console.WriteLine($"AtlusScriptCompiler {Version.Major}.{Version.Minor}-{ThisAssembly.Git.Commit} by TGE");
            Console.WriteLine();
            Console.WriteLine("Note: If you encounter any issues, please report it & include the AtlusScriptCompiler.log file. Thank you.");
            Console.WriteLine();
            Console.WriteLine("Parameter overview:");
            Console.WriteLine("    General:");
            Console.WriteLine("        -In                     <path to file>      Provides an input file source to the compiler. If no input source is explicitly specified, ");
            Console.WriteLine("                                                    the first argument will be assumed to be one.");
            Console.WriteLine("        -InFormat               <format>            Specifies the input file source format. By default this is guessed by the file extension.");
            Console.WriteLine("        -Out                    <path to file>      Provides an output file path to the compiler. If no output source is explicitly specified, ");
            Console.WriteLine("                                                    the file will be output in the same folder as the source file under a different extension depending on the format used.");
            Console.WriteLine("        -OutFormat              <format>            Specifies the binary output file format. See below for further info.");
            Console.WriteLine("        -Compile                                    Instructs the compiler to compile the provided input file source.");
            Console.WriteLine("        -Decompile                                  Instructs the compiler to decompile the provided input file source.");
            Console.WriteLine("        -Disassemble                                Instructs the compiler to disassemble the provided input file source.");
            Console.WriteLine("        -Library                <name>              Specifies the name of the library that should be used.");
            Console.WriteLine("        -LogTrace                                   Outputs trace log messages to the console");
            Console.WriteLine("        -UPatch                 <path to file>      Patches an existing BF/BMD uasset to insert the newly compiled file into, including fixing file lengths. For Persona 3 Reload");
            Console.WriteLine();
            Console.WriteLine("    MessageScript:");
            Console.WriteLine("        -Encoding               <format>            Specifies the MessageScript binary output text encoding. See below for further info.");
            Console.WriteLine();
            Console.WriteLine("    FlowScript:");
            Console.WriteLine("        -TraceProcedure                            Enables procedure tracing. Only applies to compiler.");
            Console.WriteLine("        -TraceProcedureCalls                       Enables procedure call tracing. Only applies to compiler.");
            Console.WriteLine("        -TraceFunctionCalls                        Enables function call tracing. Only applies to compiler.");
            Console.WriteLine("        -StackCookie                               Enables stack cookie. Used for debugging stack corruptions.");
            Console.WriteLine("        -Hook                                      Enables hooking of procedures. Used to modify scripts without recompiling them entirely.");
            Console.WriteLine("        -SumBits                                   Sums the bit id values passed to BIT_* functions");
            Console.WriteLine("        -OverwriteMessages                         Causes messages with duplicate names to overwrite existing messages.");
            Console.WriteLine();
            Console.WriteLine("Parameter detailed info:");
            Console.WriteLine("    MessageScript:");
            Console.WriteLine("        -OutFormat");
            Console.WriteLine("            V1              Used by Persona 3, 4, 5 PS4");
            Console.WriteLine("            V1DDS           Used by Digital Devil Saga 1 & 2");
            Console.WriteLine("            V1BE            Used by Persona 5 PS3");
            Console.WriteLine("            V1RE            Used by Persona 3 Reload");
            Console.WriteLine("            V2              Used by Catherine: Full Body");
            Console.WriteLine("            V2BE            Used by Catherine");
            Console.WriteLine();
            Console.WriteLine("        -Encoding");
            Console.WriteLine("            Below is a list of different available standard encodings.");
            Console.WriteLine("            Note that ASCII characters don't really differ from the standard, so this mostly applies to special characters and japanese characters.");
            Console.WriteLine();
            Console.WriteLine("            ASCII                             Standard ASCII encoding.");
            Console.WriteLine("            SJ (shift-jis)                    Shift-JIS encoding (CP932). Used by Persona Q(2)");
            Console.WriteLine("            P3                                Persona 3's custom encoding");
            Console.WriteLine("            P4                                Persona 4's custom encoding");
            Console.WriteLine("            P5                                Persona 5's custom encoding");
            Console.WriteLine("            CAT                               Catherine's custom encoding");
            Console.WriteLine("            CFB                               Catherine: Full Body's custom encoding");
            Console.WriteLine("            UT (utf-8)                        UTF-8 Encoding. Used by Persona 3 Reload");
            Console.WriteLine("            Unicode (utf-16)                  UTF-16 Encoding.");
            Console.WriteLine("            Unicode Big Endian (utf-16-be)    Big Endian UTF-16 Encoding.");
            Console.WriteLine("            <charset file name>               Custom encodings can be used by placing them in the charset folder. The TSV files are tab separated.");
            Console.WriteLine("            See below for all available charsets.");
            Console.WriteLine();
            Console.WriteLine("        -Library");
            Console.WriteLine("            For MessageScripts the libraries used for the compiler and decompiler to emit the proper [f] tags for each aliased function.");
            Console.WriteLine("            If you don't use any aliased functions, you don't need to specify this, but if you do without specifying it, you'll get a compiler error.");
            Console.WriteLine("            Not specifying a library definition registry means that the decompiler will not try to look up aliases for functions.");
            Console.WriteLine("            Libraries can be found in the Libraries directory");
            Console.WriteLine("            Either the full name enclosed with quotes, or the shorthand name can be used.");
            Console.WriteLine("            See below for all available libraries.");
            Console.WriteLine();
            Console.WriteLine("    FlowScript:");
            Console.WriteLine("        -OutFormat");
            Console.WriteLine("            V1              Used by Persona 3 and 4");
            Console.WriteLine("            V1DDS           Used by Digital Devil Saga 1 & 2");
            Console.WriteLine("            V1BE            ");
            Console.WriteLine("            V2              Used by Persona 4 Dancing All Night");
            Console.WriteLine("            V2BE            ");
            Console.WriteLine("            V3              Used by Persona 5 PS4");
            Console.WriteLine("            V3BE            Used by Persona 5 PS3 & PS4");
            Console.WriteLine("            V4              Used by Persona 3 Reload");
            Console.WriteLine("            V4BE            Used by Persona 3 Reload");
            Console.WriteLine();
            Console.WriteLine("        -Library");
            Console.WriteLine("            For FlowScripts the libraries is used for the decompiler to decompile binary scripts, but it is also used to generate documentation.");
            Console.WriteLine("            Without a specified registry you cannot decompile scripts.");
            Console.WriteLine("            Libraries can be found in the Libraries directory");
            Console.WriteLine("            Either the full name enclosed with quotes, or the shorthand name can be used.");
            Console.WriteLine("            See below for all available libraries.");
            Console.WriteLine();
            Console.WriteLine("Available libraries:");
            foreach (var lib in LibraryLookup.Libraries)
                Console.WriteLine($"    {lib.Name} ({lib.ShortName})");
            Console.WriteLine();
            Console.WriteLine("Available charsets:");
            foreach (var item in AtlusEncoding.AvailableCharsets)
            {
                if (AtlusEncoding.CharsetAliases.TryGetValue(item, out var aliases))
                {
                    Console.WriteLine($"    {item} ({string.Join(", ", aliases)})");
                }
                else
                {
                    Console.WriteLine($"    {item}");
                }
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Logger.Error("No arguments specified!");
                DisplayUsage();
                return;
            }

            // Set up log listener
            Listener.Subscribe(Logger);

            // Log arguments
            Logger.Trace($"Arguments: {string.Join(" ", args)}");

            if (!TryParseArguments(args))
            {
                Logger.Error("Failed to parse arguments!");
                DisplayUsage();
                return;
            }

            if (LogTrace)
                Listener.Filter |= LogLevel.Trace;

            bool success;

#if !DEBUG
            try
#endif
            {
                if (UEWrapped)
                {
                    success = UEWrapperHandler();
                }
                if (DoCompile)
                {
                    success = TryDoCompilation();
                }
                else if (DoDecompile)
                {
                    success = TryDoDecompilation();
                }
                else if (DoDisassemble)
                {
                    success = TryDoDisassembling();
                }
                else
                {
                    Logger.Error("No compilation, decompilation or disassemble instruction given!");
                    DisplayUsage();
                    return;
                }
                if (success && UEPatchFile != null)
                {
                    if (DoCompile)
                    {
                        success = UEWrapper.WrapAsset(OutputFilePath, UEPatchFile);
                    }
                    else
                    {
                        Logger.Error("Patch file can only be used on compilation");
                        DisplayUsage();
                        return;
                    }
                }
            }
#if !DEBUG
            catch ( Exception e )
            {
                LogException( "Unhandled exception thrown", e );
                success = false;

                if ( Debugger.IsAttached )
                    throw;
            }
#endif

            if (success)
                Logger.Info("Task completed successfully!");
            else
                Logger.Error("One or more errors occured while executing task!");

            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static bool TryParseArguments(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                bool isLast = i + 1 == args.Length;

                switch (args[i])
                {
                    // General
                    case "-In":
                        if (isLast)
                        {
                            Logger.Error("Missing argument for -In parameter");
                            return false;
                        }

                        InputFilePath = args[++i];
                        break;

                    case "-InFormat":
                        if (isLast)
                        {
                            Logger.Error("Missing argument for -InFormat parameter");
                            return false;
                        }

                        if (!Enum.TryParse(args[++i], true, out InputFileFormat))
                        {
                            Logger.Error("Invalid input file format specified");
                            return false;
                        }

                        break;

                    case "-Out":
                        if (isLast)
                        {
                            Logger.Error("Missing argument for -Out parameter");
                            return false;
                        }

                        OutputFilePath = args[++i];
                        break;

                    case "-OutFormat":
                        if (isLast)
                        {
                            Logger.Error("Missing argument for -OutFormat parameter");
                            return false;
                        }

                        if (!Enum.TryParse(args[++i], true, out OutputFileFormat))
                        {
                            Logger.Error("Invalid output file format specified");
                            return false;
                        }

                        break;

                    case "-Compile":
                        if (!IsActionAssigned)
                        {
                            IsActionAssigned = true;
                        }
                        else
                        {
                            Logger.Error("Attempted to assign compilation action while another action is already assigned.");
                            return false;
                        }

                        DoCompile = true;
                        break;

                    case "-Decompile":
                        if (!IsActionAssigned)
                        {
                            IsActionAssigned = true;
                        }
                        else
                        {
                            Logger.Error("Attempted to assign decompilation action while another action is already assigned.");
                            return false;
                        }

                        DoDecompile = true;
                        break;

                    case "-Disassemble":
                        if (!IsActionAssigned)
                        {
                            IsActionAssigned = true;
                        }
                        else
                        {
                            Logger.Error("Attempted to assign disassembly action while another action is already assigned.");
                            return false;
                        }

                        DoDisassemble = true;
                        break;

                    case "-Library":
                        if (isLast)
                        {
                            Logger.Error("Missing argument for -Library parameter");
                            return false;
                        }

                        LibraryName = args[++i];
                        break;

                    case "-LogTrace":
                        LogTrace = true;
                        break;

                    // MessageScript
                    case "-Encoding":
                        if (isLast)
                        {
                            Logger.Error("Missing argument for -Encoding parameter");
                            return false;
                        }

                        MessageScriptTextEncodingName = args[++i];

                        switch (MessageScriptTextEncodingName.ToLower())
                        {
                            case "ascii":
                                MessageScriptEncoding = Encoding.ASCII;
                                break;
                            case "sj":
                            case "shiftjis":
                            case "shift-jis":
                                MessageScriptEncoding = ShiftJISEncoding.Instance;
                                break;
                            case "ut":
                            case "utf-8":
                                MessageScriptEncoding = Encoding.UTF8;
                                break;
                            case "unicode":
                            case "utf-16":
                                MessageScriptEncoding = Encoding.Unicode;
                                break;
                            case "utf-16-be":
                                MessageScriptEncoding = Encoding.BigEndianUnicode;
                                break;
                            case "cat":
                                MessageScriptEncoding = CatherineEncoding.Instance;
                                break;
                            case "cfb":
                                MessageScriptEncoding = CatherineFullBodyEncoding.Instance;
                                break;
                            default:
                                try
                                {
                                    MessageScriptEncoding = AtlusEncoding.Create(MessageScriptTextEncodingName);
                                }
                                catch (ArgumentException)
                                {
                                    Logger.Error($"Unknown encoding: {MessageScriptTextEncodingName}");
                                    return false;
                                }
                                break;
                        }

                        Logger.Info($"Using {MessageScriptTextEncodingName} encoding");
                        break;

                    case "-TraceProcedure":
                        FlowScriptEnableProcedureTracing = true;
                        break;

                    case "-TraceProcedureCalls":
                        FlowScriptEnableProcedureCallTracing = true;
                        break;

                    case "-TraceFunctionCalls":
                        FlowScriptEnableFunctionCallTracing = true;
                        break;

                    case "-StackCookie":
                        FlowScriptEnableStackCookie = true;
                        break;

                    case "-Hook":
                        FlowScriptEnableProcedureHook = true;
                        break;

                    case "-SumBits":
                        FlowScriptSumBits = true;
                        break;

                    case "-UPatch":
                        if (isLast)
                        {
                            Logger.Error("Missing argument for -UPatch parameter");
                            return false;
                        }

                        UEPatchFile = args[++i];
                        break;

                    case "-OverwriteMessages":
                        FlowScriptOverwriteMessages = true;
                        break;
                }
            }

            if (InputFilePath == null)
            {
                InputFilePath = args[0];
            }

            if (!File.Exists(InputFilePath))
            {
                Logger.Error($"Specified input file doesn't exist! ({InputFilePath})");
                return false;
            }

            if (InputFileFormat == InputFileFormat.None)
            {
                var extension = Path.GetExtension(InputFilePath);

                switch (extension.ToLowerInvariant())
                {
                    case ".bf":
                        InputFileFormat = InputFileFormat.FlowScriptBinary;
                        break;

                    case ".flow":
                        InputFileFormat = InputFileFormat.FlowScriptTextSource;
                        break;

                    case ".flowasm":
                        InputFileFormat = InputFileFormat.FlowScriptAssemblerSource;
                        break;

                    case ".bmd":
                        InputFileFormat = InputFileFormat.MessageScriptBinary;
                        break;

                    case ".msg":
                        InputFileFormat = InputFileFormat.MessageScriptTextSource;
                        break;

                    case ".uasset":
                        Logger.Error("-InFormat parameter required when working with Unreal Engine wrapped scripts");
                        return false;

                    default:
                        Logger.Error("Unable to detect input file format");
                        return false;
                }
            }

            if (Path.GetExtension(InputFilePath).ToLowerInvariant().Equals(".uasset"))
            {
                UEWrapped = true;
            }
            else
            {
                UEWrapped = false;
            }


            if (!IsActionAssigned)
            {
                // Decide on default action based on input file format
                switch (InputFileFormat)
                {
                    case InputFileFormat.FlowScriptBinary:
                    case InputFileFormat.MessageScriptBinary:
                        DoDecompile = true;
                        break;
                    case InputFileFormat.FlowScriptTextSource:
                    case InputFileFormat.MessageScriptTextSource:
                        DoCompile = true;
                        break;
                    default:
                        Logger.Error("No compilation, decompilation or disassemble instruction given!");
                        return false;
                }
            }

            if (OutputFilePath == null)
            {
                if (DoCompile)
                {
                    switch (InputFileFormat)
                    {
                        case InputFileFormat.FlowScriptTextSource:
                        case InputFileFormat.FlowScriptAssemblerSource:
                            OutputFilePath = InputFilePath + ".bf";
                            break;
                        case InputFileFormat.MessageScriptTextSource:
                            OutputFilePath = InputFilePath + ".bmd";
                            break;
                    }
                }
                else if (DoDecompile)
                {
                    switch (InputFileFormat)
                    {
                        case InputFileFormat.FlowScriptBinary:
                            OutputFilePath = InputFilePath + ".flow";
                            break;
                        case InputFileFormat.MessageScriptBinary:
                            OutputFilePath = InputFilePath + ".msg";
                            break;
                    }
                }
                else if (DoDisassemble)
                {
                    switch (InputFileFormat)
                    {
                        case InputFileFormat.FlowScriptBinary:
                            OutputFilePath = InputFilePath + ".flowasm";
                            break;
                    }
                }
            }

            if (!UEWrapped) Logger.Info($"Output file path is set to {OutputFilePath}");
            return true;
        }

        private static bool TryDoCompilation()
        {
            switch (InputFileFormat)
            {
                case InputFileFormat.FlowScriptTextSource:
                case InputFileFormat.FlowScriptAssemblerSource:
                    return TryDoFlowScriptCompilation();

                case InputFileFormat.MessageScriptTextSource:
                    return TryDoMessageScriptCompilation();

                case InputFileFormat.FlowScriptBinary:
                case InputFileFormat.MessageScriptBinary:
                    Logger.Error("Binary files can't be compiled again!");
                    return false;

                default:
                    Logger.Error("Invalid input file format!");
                    return false;
            }
        }

        private static bool TryDoFlowScriptCompilation()
        {
            Logger.Info("Compiling FlowScript...");

            // Get format verson
            var version = GetFlowScriptFormatVersion();
            if (version == FormatVersion.Unknown)
            {
                Logger.Error("Invalid FlowScript file format specified");
                return false;
            }

            // Compile source
            var compiler = new FlowScriptCompiler(version);
            compiler.AddListener(Listener);
            compiler.Encoding = MessageScriptEncoding;
            compiler.EnableProcedureTracing = FlowScriptEnableProcedureTracing;
            compiler.EnableProcedureCallTracing = FlowScriptEnableProcedureCallTracing;
            compiler.EnableFunctionCallTracing = FlowScriptEnableFunctionCallTracing;
            compiler.EnableStackCookie = FlowScriptEnableStackCookie;
            compiler.ProcedureHookMode = FlowScriptEnableProcedureHook ? ProcedureHookMode.ImportedOnly : ProcedureHookMode.None;
            compiler.OverwriteExistingMsgs = FlowScriptOverwriteMessages;

            if (LibraryName != null)
            {
                var library = LibraryLookup.GetLibrary(LibraryName);

                if (library == null)
                {
                    Logger.Error("Invalid library name specified");
                    return false;
                }

                compiler.Library = library;
            }

            FlowScript flowScript = null;
            var success = false;
            using (var file = File.Open(InputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                try
                {
                    success = compiler.TryCompile(file, out flowScript);
                }
                catch (UnsupportedCharacterException e)
                {
                    Logger.Error($"Character '{e.Character}' not supported by encoding '{e.EncodingName}'");
                }

                if (!success)
                {
                    Logger.Error("One or more errors occured during compilation!");
                    return false;
                }
            }

            // Write binary
            Logger.Info("Writing binary to file...");
            return TryPerformAction("An error occured while saving the file.", () => flowScript.ToFile(OutputFilePath));
        }

        private static FormatVersion GetFlowScriptFormatVersion()
        {
            FormatVersion version;
            switch (OutputFileFormat)
            {
                case OutputFileFormat.V1:
                    version = FormatVersion.Version1;
                    break;
                case OutputFileFormat.V1BE:
                    version = FormatVersion.Version1BigEndian;
                    break;
                case OutputFileFormat.V1DDS:
                    version = FormatVersion.Version1; // TODO: relay proper MessageScript version to FlowScript loader
                    break;
                case OutputFileFormat.V2:
                    version = FormatVersion.Version2;
                    break;
                case OutputFileFormat.V2BE:
                    version = FormatVersion.Version2BigEndian;
                    break;
                case OutputFileFormat.V3:
                    version = FormatVersion.Version3;
                    break;
                case OutputFileFormat.V3BE:
                    version = FormatVersion.Version3BigEndian;
                    break;
                case OutputFileFormat.V4:
                    version = FormatVersion.Version4;
                    break;
                case OutputFileFormat.V4BE:
                    version = FormatVersion.Version4BigEndian;
                    break;
                default:
                    version = FormatVersion.Unknown;
                    break;
            }

            return version;
        }

        private static OutputFileFormat GetOutputFileFormat(FormatVersion version)
        {
            OutputFileFormat outputFileFormat;
            switch (version)
            {
                case FormatVersion.Version1:
                    outputFileFormat = OutputFileFormat.V1;
                    break;
                case FormatVersion.Version1BigEndian:
                    outputFileFormat = OutputFileFormat.V1BE;
                    break;
                case FormatVersion.Version2:
                    outputFileFormat = OutputFileFormat.V2;
                    break;
                case FormatVersion.Version2BigEndian:
                    outputFileFormat = OutputFileFormat.V2BE;
                    break;
                case FormatVersion.Version3:
                    outputFileFormat = OutputFileFormat.V3;
                    break;
                case FormatVersion.Version3BigEndian:
                    outputFileFormat = OutputFileFormat.V3BE;
                    break;
                case FormatVersion.Version4:
                    outputFileFormat = OutputFileFormat.V4;
                    break;
                case FormatVersion.Version4BigEndian:
                    outputFileFormat = OutputFileFormat.V4BE;
                    break;
                default:
                    outputFileFormat = OutputFileFormat.None;
                    break;
            }

            return outputFileFormat;
        }

        private static bool TryDoMessageScriptCompilation()
        {
            // Compile source
            Logger.Info("Compiling MessageScript...");

            var version = GetMessageScriptFormatVersion();
            if (version == AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Detect)
            {
                Logger.Error("Invalid MessageScript file format");
                return false;
            }

            var compiler = new MessageScriptCompiler(GetMessageScriptFormatVersion(), MessageScriptEncoding);
            compiler.AddListener(Listener);

            if (LibraryName != null)
            {
                var library = LibraryLookup.GetLibrary(LibraryName);

                if (library == null)
                {
                    Logger.Error("Invalid library name specified");
                    return false;
                }

                compiler.Library = library;
            }

            bool success = false;
            MessageScript script = null;

            try
            {
                success = compiler.TryCompile(File.OpenText(InputFilePath), out script);
            }
            catch (UnsupportedCharacterException e)
            {
                Logger.Error($"Character '{e.Character}' not supported by encoding '{e.EncodingName}'");
            }

            if (!success)
            {
                Logger.Error("One or more errors occured during compilation!");
                return false;
            }

            // Write binary
            Logger.Info("Writing binary to file...");
            if (!TryPerformAction("An error occured while saving the file.", () => script.ToFile(OutputFilePath)))
                return false;

            return true;
        }

        private static AtlusScriptLibrary.MessageScriptLanguage.FormatVersion GetMessageScriptFormatVersion()
        {
            AtlusScriptLibrary.MessageScriptLanguage.FormatVersion version;

            switch (OutputFileFormat)
            {
                case OutputFileFormat.V1:
                    version = AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Version1;
                    break;
                case OutputFileFormat.V1DDS:
                    version = AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Version1DDS;
                    break;
                case OutputFileFormat.V1BE:
                    version = AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Version1BigEndian;
                    break;
                case OutputFileFormat.V1RE:
                    version = AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Version1Reload;
                    break;
                case OutputFileFormat.V2:
                    version = AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Version2;
                    break;
                case OutputFileFormat.V2BE:
                    version = AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Version2BigEndian;
                    break;
                default:
                    version = AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Detect;
                    break;
            }

            return version;
        }

        private static OutputFileFormat GetOutputFileFormatFromMessageScriptVersion(AtlusScriptLibrary.MessageScriptLanguage.FormatVersion version)
        {
            OutputFileFormat outputFileFormat;

            switch (version)
            {
                case AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Version1:
                    outputFileFormat = OutputFileFormat.V1;
                    break;
                case AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Version1DDS:
                    outputFileFormat = OutputFileFormat.V1DDS;
                    break;
                case AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Version1BigEndian:
                    outputFileFormat = OutputFileFormat.V1BE;
                    break;
                case AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Version1Reload:
                    outputFileFormat = OutputFileFormat.V1RE;
                    break;
                case AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Version2:
                    outputFileFormat = OutputFileFormat.V2;
                    break;
                case AtlusScriptLibrary.MessageScriptLanguage.FormatVersion.Version2BigEndian:
                    outputFileFormat = OutputFileFormat.V2BE;
                    break;
                default:
                    outputFileFormat = OutputFileFormat.None;
                    break;
            }

            return outputFileFormat;
        }

        private static bool TryDoDecompilation()
        {
            switch (InputFileFormat)
            {
                case InputFileFormat.FlowScriptTextSource:
                case InputFileFormat.FlowScriptAssemblerSource:
                case InputFileFormat.MessageScriptTextSource:
                    Logger.Error("Can't decompile a text source!");
                    return false;

                case InputFileFormat.FlowScriptBinary:
                    return TryDoFlowScriptDecompilation();

                case InputFileFormat.MessageScriptBinary:
                    return TryDoMessageScriptDecompilation();

                default:
                    Logger.Error("Invalid input file format!");
                    return false;
            }
        }

        private static bool TryDoFlowScriptDecompilation()
        {
            // Load binary file
            Logger.Info("Loading binary FlowScript file...");
            FlowScript flowScript = null;
            var encoding = MessageScriptEncoding;
            var format = GetFlowScriptFormatVersion();

            if (!TryPerformAction("Failed to load flow script from file", () => flowScript = FlowScript.FromFile(InputFilePath, encoding, format)))
                return false;

            Logger.Info("Decompiling FlowScript...");

            var decompiler = new FlowScriptDecompiler();
            decompiler.SumBits = FlowScriptSumBits;
            decompiler.AddListener(Listener);

            if (LibraryName != null)
            {
                var library = LibraryLookup.GetLibrary(LibraryName);

                if (library == null)
                {
                    Logger.Error("Invalid library name specified");
                    return false;
                }

                decompiler.Library = library;
            }

            if (!decompiler.TryDecompile(flowScript, OutputFilePath))
            {
                Logger.Error("Failed to decompile FlowScript");
                return false;
            }

            var outFormat = GetOutputFileFormat(flowScript!.FormatVersion);
            if (outFormat != OutputFileFormat.None)
                Logger.Info($"FlowScript version {outFormat} decompiled.");

            return true;
        }

        private static bool TryDoMessageScriptDecompilation()
        {
            // load binary file
            Logger.Info("Loading binary MessageScript file...");
            MessageScript script = null;
            var encoding = MessageScriptEncoding;
            var format = GetMessageScriptFormatVersion();

            if (!TryPerformAction("Failed to load message script from file.", () => script = MessageScript.FromFile(InputFilePath, format, encoding)))
                return false;

            Logger.Info("Decompiling MessageScript...");

            if (!TryPerformAction("Failed to decompile message script to file.", () =>
            {
                using (var decompiler = new MessageScriptDecompiler(new FileTextWriter(OutputFilePath)))
                {
                    if (LibraryName != null)
                    {
                        var library = LibraryLookup.GetLibrary(LibraryName);

                        if (library == null)
                        {
                            Logger.Error("Invalid library name specified");
                        }

                        decompiler.Library = library;
                    }

                    decompiler.Decompile(script);
                }
            }))
            {
                return false;
            }


            var outFormat = GetOutputFileFormatFromMessageScriptVersion(script.FormatVersion);
            if (outFormat != OutputFileFormat.None)
                Logger.Info($"MessageScript version {outFormat} decompiled.");

            return true;
        }

        private static bool TryDoDisassembling()
        {
            switch (InputFileFormat)
            {
                case InputFileFormat.FlowScriptTextSource:
                case InputFileFormat.FlowScriptAssemblerSource:
                case InputFileFormat.MessageScriptTextSource:
                    Logger.Error("Can't disassemble a text source!");
                    return false;

                case InputFileFormat.FlowScriptBinary:
                    return TryDoFlowScriptDisassembly();

                case InputFileFormat.MessageScriptBinary:
                    Logger.Info("Error. Disassembling message scripts is not supported.");
                    return false;

                default:
                    Logger.Error("Invalid input file format!");
                    return false;
            }
        }

        private static bool TryDoFlowScriptDisassembly()
        {
            // load binary file
            Logger.Info("Loading binary FlowScript file...");

            FlowScriptBinary script = null;
            var format = GetFlowScriptFormatVersion();

            if (!TryPerformAction("Failed to load flow script from file.", () =>
            {
                script = FlowScriptBinary.FromFile(InputFilePath, (BinaryFormatVersion)format);
            }))
            {
                return false;
            }

            Logger.Info("Disassembling FlowScript...");
            if (!TryPerformAction("Failed to disassemble flow script to file.", () =>
            {
                var disassembler = new FlowScriptBinaryDisassembler(OutputFilePath);
                disassembler.Disassemble(script);
                disassembler.Dispose();
            }))
            {
                return false;
            }

            return true;
        }

        private static bool TryPerformAction(string errorMessage, Action action)
        {
#if !DEBUG
            try
            {
#endif
            action();
#if !DEBUG
            }
            catch ( Exception e )
            {
                LogException( errorMessage, e );
                return false;
            }
#endif

            return true;
        }

        private static void LogException(string message, Exception e)
        {
            Logger.Error(message);
            Logger.Error("Exception info:");
            Logger.Error($"{e.Message}");
            Logger.Error("Stacktrace:");
            Logger.Error($"{e.StackTrace}");
        }

        private static bool UEWrapperHandler()
        {
            bool success = false;
            using (var unwrapper = File.Open(InputFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                UEWrapper.UnwrapAsset(Path.GetDirectoryName(InputFilePath), Path.GetFileNameWithoutExtension(InputFilePath), GetInputFileExtensionByFileFormat(), unwrapper, out var outName);
                InputFilePath = outName;
                OutputFilePath = InputFilePath + GetOutputFileExtensionByFileFormat();
                Logger.Info($"Input file path is set to {InputFilePath}");
                Logger.Info($"Output file path is set to {OutputFilePath}");
    }
            return success;
        }

        private static string GetInputFileExtensionByFileFormat()
        {
            switch (InputFileFormat)
            {
                case InputFileFormat.FlowScriptBinary:
                    return ".bf";
                case InputFileFormat.MessageScriptBinary:
                    return ".bmd";
                default:
                    throw new Exception("Couldn't determine an input file extension");
            }
        }

        private static string GetOutputFileExtensionByFileFormat()
        {
            switch (InputFileFormat)
            {
                case InputFileFormat.FlowScriptTextSource:
                case InputFileFormat.FlowScriptAssemblerSource:
                    return ".bf";
                case InputFileFormat.MessageScriptTextSource:
                    return ".bmd";

                case InputFileFormat.FlowScriptBinary:
                    if (DoDecompile) return ".flow";
                    return ".flowasm";
                case InputFileFormat.MessageScriptBinary:
                    return ".msg";

                default:
                    throw new Exception("Couldn't determine an output file extension");
            }
        }
    }

    public enum InputFileFormat
    {
        None,
        FlowScriptBinary,
        FlowScriptTextSource,
        FlowScriptAssemblerSource,
        MessageScriptBinary,
        MessageScriptTextSource
    }

    public enum OutputFileFormat
    {
        None,
        V1,
        V1DDS,
        V1BE,
        V1RE,
        V2,
        V2BE,
        V3,
        V3BE,
        V4,
        V4BE,
    }
}