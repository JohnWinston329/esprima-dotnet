using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Esprima.Ast
{
    public class Program : Statement/*, IVariableScope, IFunctionScope*/
    {
        public IEnumerable<StatementListItem> Body;

        [JsonConverter(typeof(StringEnumConverter), new object[] { true })]
        public SourceType SourceType;

        public Program(IEnumerable<StatementListItem> body, SourceType sourceType)
        {
            Type = Nodes.Program;
            Body = body;
            SourceType = sourceType;
        }

        public bool IsStrict()
        {
            foreach(var statement in Body)
            {
                // A directive uses Tokens.Expression, so it can't
                // be detected using Type
                var directive = statement as Directive;
                if (directive == null)
                {
                    return false;
                }

                return directive.Directiv == "use strict";
            }

            return false;
        }
    }
}