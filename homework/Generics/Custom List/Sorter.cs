using System;

static class Sorter
{
    public static void Sort<TItem>(this CustomList<TItem> myList) where TItem : IComparable
    {
        try
        {
            for (int i = 0; true; i++)
            {
                var current = myList[i];
                var next = myList[i + 1];

                if (current.CompareTo(next) > 0)
                {
                    myList[i] = next;
                    myList[i + 1] = current;
                    i = -1;
                }
            }
        }
        catch (Exception)
        {
            // ignored
        }
    }
}