﻿using System.Diagnostics;
using System.Runtime.CompilerServices;
using Esprima.Utils.Jsx;

namespace Esprima.Ast.Jsx;

[DebuggerDisplay("{Namespace,nq}.{Name,nq}")]
public sealed class JsxNamespacedName : JsxExpression
{
    public JsxNamespacedName(JsxIdentifier @namespace, JsxIdentifier name) : base(JsxNodeType.NamespacedName)
    {
        Namespace = @namespace;
        Name = name;
    }

    public JsxIdentifier Namespace { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }
    public JsxIdentifier Name { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

    public override NodeCollection ChildNodes => new(Name, Namespace);

    protected override object? Accept(IJsxAstVisitor visitor)
    {
        return visitor.VisitJsxNamespacedName(this);
    }

    public JsxNamespacedName UpdateWith(JsxIdentifier name, JsxIdentifier @namespace)
    {
        if (name == Name && @namespace == Namespace)
        {
            return this;
        }

        return new JsxNamespacedName(@namespace, name).SetAdditionalInfo(this);
    }
}