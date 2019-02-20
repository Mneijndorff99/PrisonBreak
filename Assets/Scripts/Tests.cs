using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tests : MonoBehaviour
{

    private void Start()
    {
        TestInventory();
    }

    void TestInventory()
    {
        BonusItem bonus = new BonusItem("Bonus1", 2f, 100);
        BonusItem anvil = new BonusItem("Bonus1", 9f, 900);
        AccesItem key = new AccesItem("Key1", 2f, 1);

       // Debug.Log("Adding Bonus succes : " + Inventory.instance.AddItem(bonus)); 
        Debug.Log("Adding Key succes : " + Inventory.instance.AddItem(key));
        Debug.Log("Adding Anvil succes : " + Inventory.instance.AddItem(anvil)); 
        Debug.Log("");
        Debug.Log("Inventory: ");
        Inventory.instance.PrintToConsole();

        Inventory.instance.RemoveItem(bonus);
        Debug.Log("INVENTORY AFTER REMOVING");
        Inventory.instance.PrintToConsole();
        Debug.Log("INVENTORY AFTER Fake REMOVING");
        Inventory.instance.RemoveItem(anvil);
        Inventory.instance.PrintToConsole();

    }

}
