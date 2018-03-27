//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.4
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from ..\..\..\AtlusScriptLib\FlowScriptLanguage\Compiler\Parser\Grammar\FlowScript.g4 by ANTLR 4.6.4

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace AtlusScriptLibrary.FlowScriptLanguage.Compiler.Parser.Grammar {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.4")]
[System.CLSCompliant(false)]
public partial class FlowScriptLexer : Lexer {
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		T__24=25, T__25=26, T__26=27, T__27=28, T__28=29, T__29=30, Import=31, 
		Function=32, Global=33, Const=34, AiLocal=35, AiGlobal=36, Bit=37, Enum=38, 
		Out=39, If=40, Else=41, For=42, While=43, Break=44, Continue=45, Return=46, 
		Goto=47, Switch=48, Case=49, Default=50, BoolLiteral=51, IntLiteral=52, 
		FloatLiteral=53, StringLiteral=54, Identifier=55, PrimitiveTypeIdentifier=56, 
		ProcedureIdentifier=57, Whitespace=58, Newline=59, BlockComment=60, LineComment=61;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "T__19", "T__20", "T__21", "T__22", "T__23", "T__24", 
		"T__25", "T__26", "T__27", "T__28", "T__29", "Import", "Function", "Global", 
		"Const", "AiLocal", "AiGlobal", "Bit", "Enum", "Out", "If", "Else", "For", 
		"While", "Break", "Continue", "Return", "Goto", "Switch", "Case", "Default", 
		"BoolLiteral", "True", "False", "IntLiteral", "DecIntLiteral", "HexIntLiteral", 
		"FloatLiteral", "FloatLiteralSuffix", "FloatLiteralExponent", "StringLiteral", 
		"StringEscapeSequence", "StringDecimalEscape", "StringHexEscape", "Identifier", 
		"PrimitiveTypeIdentifier", "ProcedureIdentifier", "Letter", "Digit", "HexDigit", 
		"HexLiteralPrefix", "Sign", "LetterOrUnderscore", "LetterOrUnderscoreOrDigit", 
		"Whitespace", "Newline", "BlockComment", "LineComment"
	};


	public FlowScriptLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "';'", "'{'", "'}'", "'='", "','", "':'", "'.'", "'--'", 
		"'++'", "'!'", "'-'", "'*'", "'/'", "'%'", "'+'", "'<'", "'>'", "'<='", 
		"'>='", "'=='", "'!='", "'&&'", "'||'", "'+='", "'-='", "'*='", "'/='", 
		"'%='", "'import'", "'function'", "'global'", "'const'", "'ai_local'", 
		"'ai_global'", "'bit'", "'enum'", "'out'", "'if'", "'else'", "'for'", 
		"'while'", "'break'", "'continue'", "'return'", "'goto'", "'switch'", 
		"'case'", "'default'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, "Import", "Function", "Global", 
		"Const", "AiLocal", "AiGlobal", "Bit", "Enum", "Out", "If", "Else", "For", 
		"While", "Break", "Continue", "Return", "Goto", "Switch", "Case", "Default", 
		"BoolLiteral", "IntLiteral", "FloatLiteral", "StringLiteral", "Identifier", 
		"PrimitiveTypeIdentifier", "ProcedureIdentifier", "Whitespace", "Newline", 
		"BlockComment", "LineComment"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "FlowScript.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2?\x239\b\x1\x4\x2"+
		"\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b\x4"+
		"\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4\x10"+
		"\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15\t\x15"+
		"\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x4\x19\t\x19\x4\x1A\t\x1A\x4\x1B"+
		"\t\x1B\x4\x1C\t\x1C\x4\x1D\t\x1D\x4\x1E\t\x1E\x4\x1F\t\x1F\x4 \t \x4!"+
		"\t!\x4\"\t\"\x4#\t#\x4$\t$\x4%\t%\x4&\t&\x4\'\t\'\x4(\t(\x4)\t)\x4*\t"+
		"*\x4+\t+\x4,\t,\x4-\t-\x4.\t.\x4/\t/\x4\x30\t\x30\x4\x31\t\x31\x4\x32"+
		"\t\x32\x4\x33\t\x33\x4\x34\t\x34\x4\x35\t\x35\x4\x36\t\x36\x4\x37\t\x37"+
		"\x4\x38\t\x38\x4\x39\t\x39\x4:\t:\x4;\t;\x4<\t<\x4=\t=\x4>\t>\x4?\t?\x4"+
		"@\t@\x4\x41\t\x41\x4\x42\t\x42\x4\x43\t\x43\x4\x44\t\x44\x4\x45\t\x45"+
		"\x4\x46\t\x46\x4G\tG\x4H\tH\x4I\tI\x4J\tJ\x4K\tK\x4L\tL\x4M\tM\x4N\tN"+
		"\x3\x2\x3\x2\x3\x3\x3\x3\x3\x4\x3\x4\x3\x5\x3\x5\x3\x6\x3\x6\x3\a\x3\a"+
		"\x3\b\x3\b\x3\t\x3\t\x3\n\x3\n\x3\v\x3\v\x3\v\x3\f\x3\f\x3\f\x3\r\x3\r"+
		"\x3\xE\x3\xE\x3\xF\x3\xF\x3\x10\x3\x10\x3\x11\x3\x11\x3\x12\x3\x12\x3"+
		"\x13\x3\x13\x3\x14\x3\x14\x3\x15\x3\x15\x3\x15\x3\x16\x3\x16\x3\x16\x3"+
		"\x17\x3\x17\x3\x17\x3\x18\x3\x18\x3\x18\x3\x19\x3\x19\x3\x19\x3\x1A\x3"+
		"\x1A\x3\x1A\x3\x1B\x3\x1B\x3\x1B\x3\x1C\x3\x1C\x3\x1C\x3\x1D\x3\x1D\x3"+
		"\x1D\x3\x1E\x3\x1E\x3\x1E\x3\x1F\x3\x1F\x3\x1F\x3 \x3 \x3 \x3 \x3 \x3"+
		" \x3 \x3!\x3!\x3!\x3!\x3!\x3!\x3!\x3!\x3!\x3\"\x3\"\x3\"\x3\"\x3\"\x3"+
		"\"\x3\"\x3#\x3#\x3#\x3#\x3#\x3#\x3$\x3$\x3$\x3$\x3$\x3$\x3$\x3$\x3$\x3"+
		"%\x3%\x3%\x3%\x3%\x3%\x3%\x3%\x3%\x3%\x3&\x3&\x3&\x3&\x3\'\x3\'\x3\'\x3"+
		"\'\x3\'\x3(\x3(\x3(\x3(\x3)\x3)\x3)\x3*\x3*\x3*\x3*\x3*\x3+\x3+\x3+\x3"+
		"+\x3,\x3,\x3,\x3,\x3,\x3,\x3-\x3-\x3-\x3-\x3-\x3-\x3.\x3.\x3.\x3.\x3."+
		"\x3.\x3.\x3.\x3.\x3/\x3/\x3/\x3/\x3/\x3/\x3/\x3\x30\x3\x30\x3\x30\x3\x30"+
		"\x3\x30\x3\x31\x3\x31\x3\x31\x3\x31\x3\x31\x3\x31\x3\x31\x3\x32\x3\x32"+
		"\x3\x32\x3\x32\x3\x32\x3\x33\x3\x33\x3\x33\x3\x33\x3\x33\x3\x33\x3\x33"+
		"\x3\x33\x3\x34\x3\x34\x5\x34\x167\n\x34\x3\x35\x3\x35\x3\x35\x3\x35\x3"+
		"\x35\x3\x36\x3\x36\x3\x36\x3\x36\x3\x36\x3\x36\x3\x37\x3\x37\x5\x37\x176"+
		"\n\x37\x3\x38\x5\x38\x179\n\x38\x3\x38\x6\x38\x17C\n\x38\r\x38\xE\x38"+
		"\x17D\x3\x39\x5\x39\x181\n\x39\x3\x39\x3\x39\x6\x39\x185\n\x39\r\x39\xE"+
		"\x39\x186\x3:\x5:\x18A\n:\x3:\a:\x18D\n:\f:\xE:\x190\v:\x3:\x5:\x193\n"+
		":\x3:\x6:\x196\n:\r:\xE:\x197\x3:\x3:\x5:\x19C\n:\x3:\x6:\x19F\n:\r:\xE"+
		":\x1A0\x5:\x1A3\n:\x3:\x5:\x1A6\n:\x3;\x3;\x3<\x3<\x3=\x3=\x3=\a=\x1AF"+
		"\n=\f=\xE=\x1B2\v=\x3=\x3=\x3>\x3>\x5>\x1B8\n>\x3>\x3>\x5>\x1BC\n>\x3"+
		">\x3>\x3>\x5>\x1C1\n>\x3?\x3?\x3?\x3?\x3?\x3?\x3?\x3?\x3?\x3?\x3?\x5?"+
		"\x1CE\n?\x3@\x3@\x3@\x3@\x3@\x3\x41\x3\x41\a\x41\x1D7\n\x41\f\x41\xE\x41"+
		"\x1DA\v\x41\x3\x42\x3\x42\x3\x42\x3\x42\x3\x42\x3\x42\x3\x42\x3\x42\x3"+
		"\x42\x3\x42\x3\x42\x3\x42\x3\x42\x3\x42\x3\x42\x3\x42\x3\x42\x3\x42\x3"+
		"\x42\x3\x42\x3\x42\x3\x42\x5\x42\x1F2\n\x42\x3\x43\x3\x43\a\x43\x1F6\n"+
		"\x43\f\x43\xE\x43\x1F9\v\x43\x3\x44\x3\x44\x3\x45\x3\x45\x3\x46\x3\x46"+
		"\x5\x46\x201\n\x46\x3G\x3G\x3G\x3H\x3H\x3I\x3I\x5I\x20A\nI\x3J\x3J\x3"+
		"J\x5J\x20F\nJ\x3K\x6K\x212\nK\rK\xEK\x213\x3K\x3K\x3L\x3L\x5L\x21A\nL"+
		"\x3L\x5L\x21D\nL\x3L\x3L\x3M\x3M\x3M\x3M\aM\x225\nM\fM\xEM\x228\vM\x3"+
		"M\x3M\x3M\x3M\x3M\x3N\x3N\x3N\x3N\aN\x233\nN\fN\xEN\x236\vN\x3N\x3N\x3"+
		"\x226\x2\x2O\x3\x2\x3\x5\x2\x4\a\x2\x5\t\x2\x6\v\x2\a\r\x2\b\xF\x2\t\x11"+
		"\x2\n\x13\x2\v\x15\x2\f\x17\x2\r\x19\x2\xE\x1B\x2\xF\x1D\x2\x10\x1F\x2"+
		"\x11!\x2\x12#\x2\x13%\x2\x14\'\x2\x15)\x2\x16+\x2\x17-\x2\x18/\x2\x19"+
		"\x31\x2\x1A\x33\x2\x1B\x35\x2\x1C\x37\x2\x1D\x39\x2\x1E;\x2\x1F=\x2 ?"+
		"\x2!\x41\x2\"\x43\x2#\x45\x2$G\x2%I\x2&K\x2\'M\x2(O\x2)Q\x2*S\x2+U\x2"+
		",W\x2-Y\x2.[\x2/]\x2\x30_\x2\x31\x61\x2\x32\x63\x2\x33\x65\x2\x34g\x2"+
		"\x35i\x2\x2k\x2\x2m\x2\x36o\x2\x2q\x2\x2s\x2\x37u\x2\x2w\x2\x2y\x2\x38"+
		"{\x2\x2}\x2\x2\x7F\x2\x2\x81\x2\x39\x83\x2:\x85\x2;\x87\x2\x2\x89\x2\x2"+
		"\x8B\x2\x2\x8D\x2\x2\x8F\x2\x2\x91\x2\x2\x93\x2\x2\x95\x2<\x97\x2=\x99"+
		"\x2>\x9B\x2?\x3\x2\xE\x4\x2HHhh\x4\x2GGgg\x4\x2$$^^\f\x2$$))^^\x63\x64"+
		"hhppttvvxx||\x3\x2\x32\x34\x4\x2\x43\\\x63|\x3\x2\x32;\x4\x2\x43H\x63"+
		"h\x4\x2ZZzz\x4\x2--//\x4\x2\v\v\"\"\x4\x2\f\f\xF\xF\x24D\x2\x3\x3\x2\x2"+
		"\x2\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3\x2\x2"+
		"\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x2\x13\x3\x2"+
		"\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2\x2\x2\x2\x1B"+
		"\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x2!\x3\x2\x2\x2\x2"+
		"#\x3\x2\x2\x2\x2%\x3\x2\x2\x2\x2\'\x3\x2\x2\x2\x2)\x3\x2\x2\x2\x2+\x3"+
		"\x2\x2\x2\x2-\x3\x2\x2\x2\x2/\x3\x2\x2\x2\x2\x31\x3\x2\x2\x2\x2\x33\x3"+
		"\x2\x2\x2\x2\x35\x3\x2\x2\x2\x2\x37\x3\x2\x2\x2\x2\x39\x3\x2\x2\x2\x2"+
		";\x3\x2\x2\x2\x2=\x3\x2\x2\x2\x2?\x3\x2\x2\x2\x2\x41\x3\x2\x2\x2\x2\x43"+
		"\x3\x2\x2\x2\x2\x45\x3\x2\x2\x2\x2G\x3\x2\x2\x2\x2I\x3\x2\x2\x2\x2K\x3"+
		"\x2\x2\x2\x2M\x3\x2\x2\x2\x2O\x3\x2\x2\x2\x2Q\x3\x2\x2\x2\x2S\x3\x2\x2"+
		"\x2\x2U\x3\x2\x2\x2\x2W\x3\x2\x2\x2\x2Y\x3\x2\x2\x2\x2[\x3\x2\x2\x2\x2"+
		"]\x3\x2\x2\x2\x2_\x3\x2\x2\x2\x2\x61\x3\x2\x2\x2\x2\x63\x3\x2\x2\x2\x2"+
		"\x65\x3\x2\x2\x2\x2g\x3\x2\x2\x2\x2m\x3\x2\x2\x2\x2s\x3\x2\x2\x2\x2y\x3"+
		"\x2\x2\x2\x2\x81\x3\x2\x2\x2\x2\x83\x3\x2\x2\x2\x2\x85\x3\x2\x2\x2\x2"+
		"\x95\x3\x2\x2\x2\x2\x97\x3\x2\x2\x2\x2\x99\x3\x2\x2\x2\x2\x9B\x3\x2\x2"+
		"\x2\x3\x9D\x3\x2\x2\x2\x5\x9F\x3\x2\x2\x2\a\xA1\x3\x2\x2\x2\t\xA3\x3\x2"+
		"\x2\x2\v\xA5\x3\x2\x2\x2\r\xA7\x3\x2\x2\x2\xF\xA9\x3\x2\x2\x2\x11\xAB"+
		"\x3\x2\x2\x2\x13\xAD\x3\x2\x2\x2\x15\xAF\x3\x2\x2\x2\x17\xB2\x3\x2\x2"+
		"\x2\x19\xB5\x3\x2\x2\x2\x1B\xB7\x3\x2\x2\x2\x1D\xB9\x3\x2\x2\x2\x1F\xBB"+
		"\x3\x2\x2\x2!\xBD\x3\x2\x2\x2#\xBF\x3\x2\x2\x2%\xC1\x3\x2\x2\x2\'\xC3"+
		"\x3\x2\x2\x2)\xC5\x3\x2\x2\x2+\xC8\x3\x2\x2\x2-\xCB\x3\x2\x2\x2/\xCE\x3"+
		"\x2\x2\x2\x31\xD1\x3\x2\x2\x2\x33\xD4\x3\x2\x2\x2\x35\xD7\x3\x2\x2\x2"+
		"\x37\xDA\x3\x2\x2\x2\x39\xDD\x3\x2\x2\x2;\xE0\x3\x2\x2\x2=\xE3\x3\x2\x2"+
		"\x2?\xE6\x3\x2\x2\x2\x41\xED\x3\x2\x2\x2\x43\xF6\x3\x2\x2\x2\x45\xFD\x3"+
		"\x2\x2\x2G\x103\x3\x2\x2\x2I\x10C\x3\x2\x2\x2K\x116\x3\x2\x2\x2M\x11A"+
		"\x3\x2\x2\x2O\x11F\x3\x2\x2\x2Q\x123\x3\x2\x2\x2S\x126\x3\x2\x2\x2U\x12B"+
		"\x3\x2\x2\x2W\x12F\x3\x2\x2\x2Y\x135\x3\x2\x2\x2[\x13B\x3\x2\x2\x2]\x144"+
		"\x3\x2\x2\x2_\x14B\x3\x2\x2\x2\x61\x150\x3\x2\x2\x2\x63\x157\x3\x2\x2"+
		"\x2\x65\x15C\x3\x2\x2\x2g\x166\x3\x2\x2\x2i\x168\x3\x2\x2\x2k\x16D\x3"+
		"\x2\x2\x2m\x175\x3\x2\x2\x2o\x178\x3\x2\x2\x2q\x180\x3\x2\x2\x2s\x189"+
		"\x3\x2\x2\x2u\x1A7\x3\x2\x2\x2w\x1A9\x3\x2\x2\x2y\x1AB\x3\x2\x2\x2{\x1C0"+
		"\x3\x2\x2\x2}\x1CD\x3\x2\x2\x2\x7F\x1CF\x3\x2\x2\x2\x81\x1D4\x3\x2\x2"+
		"\x2\x83\x1F1\x3\x2\x2\x2\x85\x1F3\x3\x2\x2\x2\x87\x1FA\x3\x2\x2\x2\x89"+
		"\x1FC\x3\x2\x2\x2\x8B\x200\x3\x2\x2\x2\x8D\x202\x3\x2\x2\x2\x8F\x205\x3"+
		"\x2\x2\x2\x91\x209\x3\x2\x2\x2\x93\x20E\x3\x2\x2\x2\x95\x211\x3\x2\x2"+
		"\x2\x97\x21C\x3\x2\x2\x2\x99\x220\x3\x2\x2\x2\x9B\x22E\x3\x2\x2\x2\x9D"+
		"\x9E\a*\x2\x2\x9E\x4\x3\x2\x2\x2\x9F\xA0\a+\x2\x2\xA0\x6\x3\x2\x2\x2\xA1"+
		"\xA2\a=\x2\x2\xA2\b\x3\x2\x2\x2\xA3\xA4\a}\x2\x2\xA4\n\x3\x2\x2\x2\xA5"+
		"\xA6\a\x7F\x2\x2\xA6\f\x3\x2\x2\x2\xA7\xA8\a?\x2\x2\xA8\xE\x3\x2\x2\x2"+
		"\xA9\xAA\a.\x2\x2\xAA\x10\x3\x2\x2\x2\xAB\xAC\a<\x2\x2\xAC\x12\x3\x2\x2"+
		"\x2\xAD\xAE\a\x30\x2\x2\xAE\x14\x3\x2\x2\x2\xAF\xB0\a/\x2\x2\xB0\xB1\a"+
		"/\x2\x2\xB1\x16\x3\x2\x2\x2\xB2\xB3\a-\x2\x2\xB3\xB4\a-\x2\x2\xB4\x18"+
		"\x3\x2\x2\x2\xB5\xB6\a#\x2\x2\xB6\x1A\x3\x2\x2\x2\xB7\xB8\a/\x2\x2\xB8"+
		"\x1C\x3\x2\x2\x2\xB9\xBA\a,\x2\x2\xBA\x1E\x3\x2\x2\x2\xBB\xBC\a\x31\x2"+
		"\x2\xBC \x3\x2\x2\x2\xBD\xBE\a\'\x2\x2\xBE\"\x3\x2\x2\x2\xBF\xC0\a-\x2"+
		"\x2\xC0$\x3\x2\x2\x2\xC1\xC2\a>\x2\x2\xC2&\x3\x2\x2\x2\xC3\xC4\a@\x2\x2"+
		"\xC4(\x3\x2\x2\x2\xC5\xC6\a>\x2\x2\xC6\xC7\a?\x2\x2\xC7*\x3\x2\x2\x2\xC8"+
		"\xC9\a@\x2\x2\xC9\xCA\a?\x2\x2\xCA,\x3\x2\x2\x2\xCB\xCC\a?\x2\x2\xCC\xCD"+
		"\a?\x2\x2\xCD.\x3\x2\x2\x2\xCE\xCF\a#\x2\x2\xCF\xD0\a?\x2\x2\xD0\x30\x3"+
		"\x2\x2\x2\xD1\xD2\a(\x2\x2\xD2\xD3\a(\x2\x2\xD3\x32\x3\x2\x2\x2\xD4\xD5"+
		"\a~\x2\x2\xD5\xD6\a~\x2\x2\xD6\x34\x3\x2\x2\x2\xD7\xD8\a-\x2\x2\xD8\xD9"+
		"\a?\x2\x2\xD9\x36\x3\x2\x2\x2\xDA\xDB\a/\x2\x2\xDB\xDC\a?\x2\x2\xDC\x38"+
		"\x3\x2\x2\x2\xDD\xDE\a,\x2\x2\xDE\xDF\a?\x2\x2\xDF:\x3\x2\x2\x2\xE0\xE1"+
		"\a\x31\x2\x2\xE1\xE2\a?\x2\x2\xE2<\x3\x2\x2\x2\xE3\xE4\a\'\x2\x2\xE4\xE5"+
		"\a?\x2\x2\xE5>\x3\x2\x2\x2\xE6\xE7\ak\x2\x2\xE7\xE8\ao\x2\x2\xE8\xE9\a"+
		"r\x2\x2\xE9\xEA\aq\x2\x2\xEA\xEB\at\x2\x2\xEB\xEC\av\x2\x2\xEC@\x3\x2"+
		"\x2\x2\xED\xEE\ah\x2\x2\xEE\xEF\aw\x2\x2\xEF\xF0\ap\x2\x2\xF0\xF1\a\x65"+
		"\x2\x2\xF1\xF2\av\x2\x2\xF2\xF3\ak\x2\x2\xF3\xF4\aq\x2\x2\xF4\xF5\ap\x2"+
		"\x2\xF5\x42\x3\x2\x2\x2\xF6\xF7\ai\x2\x2\xF7\xF8\an\x2\x2\xF8\xF9\aq\x2"+
		"\x2\xF9\xFA\a\x64\x2\x2\xFA\xFB\a\x63\x2\x2\xFB\xFC\an\x2\x2\xFC\x44\x3"+
		"\x2\x2\x2\xFD\xFE\a\x65\x2\x2\xFE\xFF\aq\x2\x2\xFF\x100\ap\x2\x2\x100"+
		"\x101\au\x2\x2\x101\x102\av\x2\x2\x102\x46\x3\x2\x2\x2\x103\x104\a\x63"+
		"\x2\x2\x104\x105\ak\x2\x2\x105\x106\a\x61\x2\x2\x106\x107\an\x2\x2\x107"+
		"\x108\aq\x2\x2\x108\x109\a\x65\x2\x2\x109\x10A\a\x63\x2\x2\x10A\x10B\a"+
		"n\x2\x2\x10BH\x3\x2\x2\x2\x10C\x10D\a\x63\x2\x2\x10D\x10E\ak\x2\x2\x10E"+
		"\x10F\a\x61\x2\x2\x10F\x110\ai\x2\x2\x110\x111\an\x2\x2\x111\x112\aq\x2"+
		"\x2\x112\x113\a\x64\x2\x2\x113\x114\a\x63\x2\x2\x114\x115\an\x2\x2\x115"+
		"J\x3\x2\x2\x2\x116\x117\a\x64\x2\x2\x117\x118\ak\x2\x2\x118\x119\av\x2"+
		"\x2\x119L\x3\x2\x2\x2\x11A\x11B\ag\x2\x2\x11B\x11C\ap\x2\x2\x11C\x11D"+
		"\aw\x2\x2\x11D\x11E\ao\x2\x2\x11EN\x3\x2\x2\x2\x11F\x120\aq\x2\x2\x120"+
		"\x121\aw\x2\x2\x121\x122\av\x2\x2\x122P\x3\x2\x2\x2\x123\x124\ak\x2\x2"+
		"\x124\x125\ah\x2\x2\x125R\x3\x2\x2\x2\x126\x127\ag\x2\x2\x127\x128\an"+
		"\x2\x2\x128\x129\au\x2\x2\x129\x12A\ag\x2\x2\x12AT\x3\x2\x2\x2\x12B\x12C"+
		"\ah\x2\x2\x12C\x12D\aq\x2\x2\x12D\x12E\at\x2\x2\x12EV\x3\x2\x2\x2\x12F"+
		"\x130\ay\x2\x2\x130\x131\aj\x2\x2\x131\x132\ak\x2\x2\x132\x133\an\x2\x2"+
		"\x133\x134\ag\x2\x2\x134X\x3\x2\x2\x2\x135\x136\a\x64\x2\x2\x136\x137"+
		"\at\x2\x2\x137\x138\ag\x2\x2\x138\x139\a\x63\x2\x2\x139\x13A\am\x2\x2"+
		"\x13AZ\x3\x2\x2\x2\x13B\x13C\a\x65\x2\x2\x13C\x13D\aq\x2\x2\x13D\x13E"+
		"\ap\x2\x2\x13E\x13F\av\x2\x2\x13F\x140\ak\x2\x2\x140\x141\ap\x2\x2\x141"+
		"\x142\aw\x2\x2\x142\x143\ag\x2\x2\x143\\\x3\x2\x2\x2\x144\x145\at\x2\x2"+
		"\x145\x146\ag\x2\x2\x146\x147\av\x2\x2\x147\x148\aw\x2\x2\x148\x149\a"+
		"t\x2\x2\x149\x14A\ap\x2\x2\x14A^\x3\x2\x2\x2\x14B\x14C\ai\x2\x2\x14C\x14D"+
		"\aq\x2\x2\x14D\x14E\av\x2\x2\x14E\x14F\aq\x2\x2\x14F`\x3\x2\x2\x2\x150"+
		"\x151\au\x2\x2\x151\x152\ay\x2\x2\x152\x153\ak\x2\x2\x153\x154\av\x2\x2"+
		"\x154\x155\a\x65\x2\x2\x155\x156\aj\x2\x2\x156\x62\x3\x2\x2\x2\x157\x158"+
		"\a\x65\x2\x2\x158\x159\a\x63\x2\x2\x159\x15A\au\x2\x2\x15A\x15B\ag\x2"+
		"\x2\x15B\x64\x3\x2\x2\x2\x15C\x15D\a\x66\x2\x2\x15D\x15E\ag\x2\x2\x15E"+
		"\x15F\ah\x2\x2\x15F\x160\a\x63\x2\x2\x160\x161\aw\x2\x2\x161\x162\an\x2"+
		"\x2\x162\x163\av\x2\x2\x163\x66\x3\x2\x2\x2\x164\x167\x5i\x35\x2\x165"+
		"\x167\x5k\x36\x2\x166\x164\x3\x2\x2\x2\x166\x165\x3\x2\x2\x2\x167h\x3"+
		"\x2\x2\x2\x168\x169\av\x2\x2\x169\x16A\at\x2\x2\x16A\x16B\aw\x2\x2\x16B"+
		"\x16C\ag\x2\x2\x16Cj\x3\x2\x2\x2\x16D\x16E\ah\x2\x2\x16E\x16F\a\x63\x2"+
		"\x2\x16F\x170\an\x2\x2\x170\x171\au\x2\x2\x171\x172\ag\x2\x2\x172l\x3"+
		"\x2\x2\x2\x173\x176\x5o\x38\x2\x174\x176\x5q\x39\x2\x175\x173\x3\x2\x2"+
		"\x2\x175\x174\x3\x2\x2\x2\x176n\x3\x2\x2\x2\x177\x179\x5\x8FH\x2\x178"+
		"\x177\x3\x2\x2\x2\x178\x179\x3\x2\x2\x2\x179\x17B\x3\x2\x2\x2\x17A\x17C"+
		"\x5\x89\x45\x2\x17B\x17A\x3\x2\x2\x2\x17C\x17D\x3\x2\x2\x2\x17D\x17B\x3"+
		"\x2\x2\x2\x17D\x17E\x3\x2\x2\x2\x17Ep\x3\x2\x2\x2\x17F\x181\x5\x8FH\x2"+
		"\x180\x17F\x3\x2\x2\x2\x180\x181\x3\x2\x2\x2\x181\x182\x3\x2\x2\x2\x182"+
		"\x184\x5\x8DG\x2\x183\x185\x5\x8B\x46\x2\x184\x183\x3\x2\x2\x2\x185\x186"+
		"\x3\x2\x2\x2\x186\x184\x3\x2\x2\x2\x186\x187\x3\x2\x2\x2\x187r\x3\x2\x2"+
		"\x2\x188\x18A\x5\x8FH\x2\x189\x188\x3\x2\x2\x2\x189\x18A\x3\x2\x2\x2\x18A"+
		"\x18E\x3\x2\x2\x2\x18B\x18D\x5\x89\x45\x2\x18C\x18B\x3\x2\x2\x2\x18D\x190"+
		"\x3\x2\x2\x2\x18E\x18C\x3\x2\x2\x2\x18E\x18F\x3\x2\x2\x2\x18F\x192\x3"+
		"\x2\x2\x2\x190\x18E\x3\x2\x2\x2\x191\x193\a\x30\x2\x2\x192\x191\x3\x2"+
		"\x2\x2\x192\x193\x3\x2\x2\x2\x193\x195\x3\x2\x2\x2\x194\x196\x5\x89\x45"+
		"\x2\x195\x194\x3\x2\x2\x2\x196\x197\x3\x2\x2\x2\x197\x195\x3\x2\x2\x2"+
		"\x197\x198\x3\x2\x2\x2\x198\x1A2\x3\x2\x2\x2\x199\x19B\x5w<\x2\x19A\x19C"+
		"\x5\x8FH\x2\x19B\x19A\x3\x2\x2\x2\x19B\x19C\x3\x2\x2\x2\x19C\x19E\x3\x2"+
		"\x2\x2\x19D\x19F\x5\x89\x45\x2\x19E\x19D\x3\x2\x2\x2\x19F\x1A0\x3\x2\x2"+
		"\x2\x1A0\x19E\x3\x2\x2\x2\x1A0\x1A1\x3\x2\x2\x2\x1A1\x1A3\x3\x2\x2\x2"+
		"\x1A2\x199\x3\x2\x2\x2\x1A2\x1A3\x3\x2\x2\x2\x1A3\x1A5\x3\x2\x2\x2\x1A4"+
		"\x1A6\x5u;\x2\x1A5\x1A4\x3\x2\x2\x2\x1A5\x1A6\x3\x2\x2\x2\x1A6t\x3\x2"+
		"\x2\x2\x1A7\x1A8\t\x2\x2\x2\x1A8v\x3\x2\x2\x2\x1A9\x1AA\t\x3\x2\x2\x1AA"+
		"x\x3\x2\x2\x2\x1AB\x1B0\a$\x2\x2\x1AC\x1AF\x5{>\x2\x1AD\x1AF\n\x4\x2\x2"+
		"\x1AE\x1AC\x3\x2\x2\x2\x1AE\x1AD\x3\x2\x2\x2\x1AF\x1B2\x3\x2\x2\x2\x1B0"+
		"\x1AE\x3\x2\x2\x2\x1B0\x1B1\x3\x2\x2\x2\x1B1\x1B3\x3\x2\x2\x2\x1B2\x1B0"+
		"\x3\x2\x2\x2\x1B3\x1B4\a$\x2\x2\x1B4z\x3\x2\x2\x2\x1B5\x1B7\a^\x2\x2\x1B6"+
		"\x1B8\t\x5\x2\x2\x1B7\x1B6\x3\x2\x2\x2\x1B8\x1C1\x3\x2\x2\x2\x1B9\x1BB"+
		"\a^\x2\x2\x1BA\x1BC\a\xF\x2\x2\x1BB\x1BA\x3\x2\x2\x2\x1BB\x1BC\x3\x2\x2"+
		"\x2\x1BC\x1BD\x3\x2\x2\x2\x1BD\x1C1\a\f\x2\x2\x1BE\x1C1\x5}?\x2\x1BF\x1C1"+
		"\x5\x7F@\x2\x1C0\x1B5\x3\x2\x2\x2\x1C0\x1B9\x3\x2\x2\x2\x1C0\x1BE\x3\x2"+
		"\x2\x2\x1C0\x1BF\x3\x2\x2\x2\x1C1|\x3\x2\x2\x2\x1C2\x1C3\a^\x2\x2\x1C3"+
		"\x1CE\x5\x89\x45\x2\x1C4\x1C5\a^\x2\x2\x1C5\x1C6\x5\x89\x45\x2\x1C6\x1C7"+
		"\x5\x89\x45\x2\x1C7\x1CE\x3\x2\x2\x2\x1C8\x1C9\a^\x2\x2\x1C9\x1CA\t\x6"+
		"\x2\x2\x1CA\x1CB\x5\x89\x45\x2\x1CB\x1CC\x5\x89\x45\x2\x1CC\x1CE\x3\x2"+
		"\x2\x2\x1CD\x1C2\x3\x2\x2\x2\x1CD\x1C4\x3\x2\x2\x2\x1CD\x1C8\x3\x2\x2"+
		"\x2\x1CE~\x3\x2\x2\x2\x1CF\x1D0\a^\x2\x2\x1D0\x1D1\az\x2\x2\x1D1\x1D2"+
		"\x5\x8B\x46\x2\x1D2\x1D3\x5\x8B\x46\x2\x1D3\x80\x3\x2\x2\x2\x1D4\x1D8"+
		"\x5\x91I\x2\x1D5\x1D7\x5\x93J\x2\x1D6\x1D5\x3\x2\x2\x2\x1D7\x1DA\x3\x2"+
		"\x2\x2\x1D8\x1D6\x3\x2\x2\x2\x1D8\x1D9\x3\x2\x2\x2\x1D9\x82\x3\x2\x2\x2"+
		"\x1DA\x1D8\x3\x2\x2\x2\x1DB\x1DC\a\x64\x2\x2\x1DC\x1DD\aq\x2\x2\x1DD\x1DE"+
		"\aq\x2\x2\x1DE\x1F2\an\x2\x2\x1DF\x1E0\ak\x2\x2\x1E0\x1E1\ap\x2\x2\x1E1"+
		"\x1F2\av\x2\x2\x1E2\x1E3\ah\x2\x2\x1E3\x1E4\an\x2\x2\x1E4\x1E5\aq\x2\x2"+
		"\x1E5\x1E6\a\x63\x2\x2\x1E6\x1F2\av\x2\x2\x1E7\x1E8\au\x2\x2\x1E8\x1E9"+
		"\av\x2\x2\x1E9\x1EA\at\x2\x2\x1EA\x1EB\ak\x2\x2\x1EB\x1EC\ap\x2\x2\x1EC"+
		"\x1F2\ai\x2\x2\x1ED\x1EE\ax\x2\x2\x1EE\x1EF\aq\x2\x2\x1EF\x1F0\ak\x2\x2"+
		"\x1F0\x1F2\a\x66\x2\x2\x1F1\x1DB\x3\x2\x2\x2\x1F1\x1DF\x3\x2\x2\x2\x1F1"+
		"\x1E2\x3\x2\x2\x2\x1F1\x1E7\x3\x2\x2\x2\x1F1\x1ED\x3\x2\x2\x2\x1F2\x84"+
		"\x3\x2\x2\x2\x1F3\x1F7\x5\x93J\x2\x1F4\x1F6\x5\x93J\x2\x1F5\x1F4\x3\x2"+
		"\x2\x2\x1F6\x1F9\x3\x2\x2\x2\x1F7\x1F5\x3\x2\x2\x2\x1F7\x1F8\x3\x2\x2"+
		"\x2\x1F8\x86\x3\x2\x2\x2\x1F9\x1F7\x3\x2\x2\x2\x1FA\x1FB\t\a\x2\x2\x1FB"+
		"\x88\x3\x2\x2\x2\x1FC\x1FD\t\b\x2\x2\x1FD\x8A\x3\x2\x2\x2\x1FE\x201\x5"+
		"\x89\x45\x2\x1FF\x201\t\t\x2\x2\x200\x1FE\x3\x2\x2\x2\x200\x1FF\x3\x2"+
		"\x2\x2\x201\x8C\x3\x2\x2\x2\x202\x203\a\x32\x2\x2\x203\x204\t\n\x2\x2"+
		"\x204\x8E\x3\x2\x2\x2\x205\x206\t\v\x2\x2\x206\x90\x3\x2\x2\x2\x207\x20A"+
		"\x5\x87\x44\x2\x208\x20A\a\x61\x2\x2\x209\x207\x3\x2\x2\x2\x209\x208\x3"+
		"\x2\x2\x2\x20A\x92\x3\x2\x2\x2\x20B\x20F\x5\x87\x44\x2\x20C\x20F\a\x61"+
		"\x2\x2\x20D\x20F\x5\x89\x45\x2\x20E\x20B\x3\x2\x2\x2\x20E\x20C\x3\x2\x2"+
		"\x2\x20E\x20D\x3\x2\x2\x2\x20F\x94\x3\x2\x2\x2\x210\x212\t\f\x2\x2\x211"+
		"\x210\x3\x2\x2\x2\x212\x213\x3\x2\x2\x2\x213\x211\x3\x2\x2\x2\x213\x214"+
		"\x3\x2\x2\x2\x214\x215\x3\x2\x2\x2\x215\x216\bK\x2\x2\x216\x96\x3\x2\x2"+
		"\x2\x217\x219\a\xF\x2\x2\x218\x21A\a\f\x2\x2\x219\x218\x3\x2\x2\x2\x219"+
		"\x21A\x3\x2\x2\x2\x21A\x21D\x3\x2\x2\x2\x21B\x21D\a\f\x2\x2\x21C\x217"+
		"\x3\x2\x2\x2\x21C\x21B\x3\x2\x2\x2\x21D\x21E\x3\x2\x2\x2\x21E\x21F\bL"+
		"\x2\x2\x21F\x98\x3\x2\x2\x2\x220\x221\a\x31\x2\x2\x221\x222\a,\x2\x2\x222"+
		"\x226\x3\x2\x2\x2\x223\x225\v\x2\x2\x2\x224\x223\x3\x2\x2\x2\x225\x228"+
		"\x3\x2\x2\x2\x226\x227\x3\x2\x2\x2\x226\x224\x3\x2\x2\x2\x227\x229\x3"+
		"\x2\x2\x2\x228\x226\x3\x2\x2\x2\x229\x22A\a,\x2\x2\x22A\x22B\a\x31\x2"+
		"\x2\x22B\x22C\x3\x2\x2\x2\x22C\x22D\bM\x2\x2\x22D\x9A\x3\x2\x2\x2\x22E"+
		"\x22F\a\x31\x2\x2\x22F\x230\a\x31\x2\x2\x230\x234\x3\x2\x2\x2\x231\x233"+
		"\n\r\x2\x2\x232\x231\x3\x2\x2\x2\x233\x236\x3\x2\x2\x2\x234\x232\x3\x2"+
		"\x2\x2\x234\x235\x3\x2\x2\x2\x235\x237\x3\x2\x2\x2\x236\x234\x3\x2\x2"+
		"\x2\x237\x238\bN\x2\x2\x238\x9C\x3\x2\x2\x2\"\x2\x166\x175\x178\x17D\x180"+
		"\x186\x189\x18E\x192\x197\x19B\x1A0\x1A2\x1A5\x1AE\x1B0\x1B7\x1BB\x1C0"+
		"\x1CD\x1D8\x1F1\x1F7\x200\x209\x20E\x213\x219\x21C\x226\x234\x3\b\x2\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace AtlusScriptLib.FlowScriptLanguage.Compiler.Parser.Grammar