class Box<T>
{
    private T val;

    public override string ToString()
    {
        return $"{typeof(T).FullName}: {val}";
    }

    public Box(T value)
    {
        this.val = value;
    }
}