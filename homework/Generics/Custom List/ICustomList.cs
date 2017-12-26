using System;

interface ICustomList<TItem> where TItem : IComparable
{
    void Add(TItem element);
    TItem Remove(int index);
    bool Contains(TItem element);
    void Swap(int index1, int index2);
    int CountGreaterThan(TItem element);
    TItem Max();
    TItem Min();
}