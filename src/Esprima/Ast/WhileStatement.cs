﻿using System.Runtime.CompilerServices;
using Esprima.Utils;

namespace Esprima.Ast;

public sealed class WhileStatement : Statement
{
    public WhileStatement(Expression test, Statement body) : base(Nodes.WhileStatement)
    {
        Test = test;
        Body = body;
    }

    public Expression Test { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }
    public Statement Body { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

    internal override Node? NextChildNode(ref ChildNodes.Enumerator enumerator) => enumerator.MoveNext(Test, Body);

    protected internal override object? Accept(AstVisitor visitor) => visitor.VisitWhileStatement(this);

    public WhileStatement UpdateWith(Expression test, Statement body)
    {
        if (test == Test && body == Body)
        {
            return this;
        }

        return new WhileStatement(test, body);
    }
}
