using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : PickUp
{
    public int points;

    protected override Item CreateItem()
    {
        return new BonusItem(objectName, weight, points);
    }
}
