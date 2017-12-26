﻿using System.Collections.Generic;

public class AddCollection : IAddable
{
    private List<string> innerCollection;

    public AddCollection()
    {
        this.innerCollection = new List<string>();
    }

    public virtual int Add(string item)
    {
        this.innerCollection.Add(item);

        return this.innerCollection.Count - 1;
    }

    protected List<string> InnerCollection => this.innerCollection;
}