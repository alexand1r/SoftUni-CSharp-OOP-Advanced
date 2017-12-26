using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class CustomList<TItem> : IEnumerable<TItem>, ICustomList<TItem> where TItem : IComparable
{
    private List<TItem> _collection;

    public TItem this[int index]
    {
        get => _collection[index];
        set => _collection[index] = value;
    }

    public void Add(TItem element)
    {
        _collection.Add(element);
    }

    public TItem Remove(int index)
    {
        var item = _collection[index];

        _collection.RemoveAt(index);

        return item;
    }

    public bool Contains(TItem element)
    {
        return _collection.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        var temp = _collection[index1];
        _collection[index1] = _collection[index2];
        _collection[index2] = temp;
    }

    public int CountGreaterThan(TItem element)
    {
        return _collection.Count(item => item.CompareTo(element) > 0);
    }

    public TItem Max()
    {
        return _collection.Max();
    }

    public TItem Min()
    {
        return _collection.Min();
    }

    public void Print()
    {
        foreach (var item in this)
        {
            Console.WriteLine(item);
        }
    }

    public CustomList()
    {
        _collection = new List<TItem>();
    }

    public IEnumerator<TItem> GetEnumerator()
    {
        return _collection.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}