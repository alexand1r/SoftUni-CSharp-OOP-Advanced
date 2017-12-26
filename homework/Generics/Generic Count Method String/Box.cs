using System;

class Box<T> : IComparable<T> where T : IComparable
{
    private T val;

    public int CompareTo(T other)
    {
        return this.val.CompareTo(other);
    }

    public override string ToString()
    {
        return $"{typeof(T).FullName}: {this.val}";
    }

    public Box(T val)
    {
        this.val = val;
    }
}