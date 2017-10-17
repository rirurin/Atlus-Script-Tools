﻿using System.Collections.Generic;
using System.Text;

namespace AtlusScriptLib.FlowScriptLanguage.Syntax
{
    public class FlowScriptProcedureDeclaration : FlowScriptDeclaration
    {
        public FlowScriptTypeIdentifier ReturnType { get; set; }

        public List<FlowScriptParameter> Parameters { get; set; }

        public FlowScriptCompoundStatement Body { get; set; }

        public FlowScriptProcedureDeclaration() : base(FlowScriptDeclarationType.Procedure)
        {
            Parameters = new List<FlowScriptParameter>();
        }

        public FlowScriptProcedureDeclaration( FlowScriptTypeIdentifier returnType, FlowScriptIdentifier identifier, List<FlowScriptParameter> parameters, FlowScriptCompoundStatement body ) : base( FlowScriptDeclarationType.Procedure, identifier )
        {
            ReturnType = returnType;
            Parameters = parameters;
            Body = body;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append( $"{ReturnType.ToString()} {Identifier.ToString()}(" );
            if ( Parameters.Count > 0 )
                builder.Append( Parameters[0].ToString() );

            for ( int i = 1; i < Parameters.Count; i++ )
            {
                builder.Append( $", {Parameters[i].ToString()}" );
            }

            builder.Append( ")" );

            if ( Body != null )
            {
                builder.Append( $"{{ {Body.ToString()} }}" );
            }

            return builder.ToString();
        }
    }
}
