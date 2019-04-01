using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<Item> items;
    public float totalWeight;
    public float maximumWeight = 10.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }


        items = new List<Item>();
    }

    public bool AddItem(Item item)
    {
        if (totalWeight + item.weight > maximumWeight)
        {
            return false;
        }

        else
        {
            items.Add(item);
            InventoryUI.instance.Add(item);
            totalWeight += item.weight;
            return true;
        }
    }

    public void RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            totalWeight -= item.weight;
        }

    }

    public bool HasKey(int ID)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] is AccesItem)
            {
                AccesItem it = (AccesItem)items[i];
                if (it.door == ID)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void removeItem(Item item)
    {
        if (items.Remove(item))
        {
            InventoryUI.instance.Remove(item);
            totalWeight -= item.weight;
        }
    }

    public void removeByName(string name)
    {
        foreach (Item i in items)
        {
            if (i.name == name)
            {
                removeItem(i);
                break;
            }
        }
    }

    public void CheckForRaftItems()
    {
        Gamemanager.instance.totalRaftparts = 0;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] is RaftItem)
            {
                Gamemanager.instance.totalRaftparts++;
            }
        }
    }
}
