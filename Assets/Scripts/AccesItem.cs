using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccesItem : Item
{
    public int door;

    public AccesItem(string name, float weight, int door) : base(name, weight)
    {
        this.door = door;
    }
}
