﻿using System.Runtime.InteropServices;

namespace Esprima;

public enum CommentType
{
    Block,
    Line
}

[StructLayout(LayoutKind.Auto)]
public readonly record struct Comment
{
    internal Comment(
        CommentType type,
        Range slice,
        int start,
        int end,
        Position startPosition,
        Position endPosition)
    {
        Type = type;
        Slice = slice;
        Start = start;
        End = end;
        StartPosition = startPosition;
        EndPosition = endPosition;
    }

    public readonly CommentType Type;

    public readonly Range Slice;

    public readonly int Start;
    public readonly int End;

    public readonly Position StartPosition;
    public readonly Position EndPosition;
}
