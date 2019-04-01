using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftItem : Item
{
    public int partNumber;

    public RaftItem(string name, float weight, int partNumber) : base(name, weight)
    {
        this.partNumber = partNumber;
    }
}
