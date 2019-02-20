using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acces : PickUp
{
    public int door;

    protected override Item CreateItem()
    {
        return new AccesItem(objectName, weight, door);
    }
}