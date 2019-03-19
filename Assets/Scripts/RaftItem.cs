using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftItem : Item
{
    public int points;

    public RaftItem(string name, float weight, int points) : base(name, weight)
    {
        this.points = points;
    }
}
