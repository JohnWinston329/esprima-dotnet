﻿using Esprima.Utils;

namespace Esprima.Ast
{
    public sealed class ThrowStatement : Statement
    {
        public readonly Expression Argument;

        public ThrowStatement(Expression argument) : base(Nodes.ThrowStatement)
        {
            Argument = argument;
        }

        public override NodeCollection ChildNodes => new(Argument);

        protected internal override object? Accept(AstVisitor visitor)
        {
            return visitor.VisitThrowStatement(this);
        }

        public ThrowStatement UpdateWith(Expression argument)
        {
            if (argument == Argument)
            {
                return this;
            }

            return new ThrowStatement(argument).SetAdditionalInfo(this);
        }

    }
}
