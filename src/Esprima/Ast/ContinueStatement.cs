namespace Esprima.Ast
{
    public class ContinueStatement : Statement
    {
        public Identifier Label;

        public ContinueStatement(Identifier label)
        {
            Type = Nodes.ContinueStatement;
            Label = label;
        }
    }
}