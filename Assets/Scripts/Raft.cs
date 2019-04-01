using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : PickUp
{
    public int partNumber;

    protected override Item CreateItem()
    {
        return new RaftItem(objectName, weight, partNumber);
    }
}
