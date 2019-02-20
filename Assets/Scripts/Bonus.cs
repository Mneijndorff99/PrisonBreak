using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : PickUp
{
    public int points;


    protected override Item CreateItem()
    {
        return new BonusItem(objectName, weight, points);
    }
}