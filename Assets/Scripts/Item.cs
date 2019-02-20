using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    public string name;
    public float weight;

    public Item(string _name, float _weight)
    {
        name = _name;
        weight = _weight;
    }
}
