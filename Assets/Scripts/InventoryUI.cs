using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;
    public Transform parent;

    public GameObject itemPrefab;
    private Dictionary<string, PickUp> items;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }

        items = new Dictionary<string, PickUp>();
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void RegisterPickUpItem(PickUp i)
    {
        if (!items.ContainsKey(i.objectName))
        {
            items.Add(i.objectName, i);
        }
    }

    public void Add(Item i)
    {
        Debug.Log("Adding item to canvas.");
        if (items.ContainsKey(i.name) && !items[i.name].isInInventory())
        {
            Debug.Log("passed tests");
            GameObject go = Instantiate(itemPrefab, parent, false);
            go.GetComponent<Image>().sprite = items[i.name].image;
            go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = i.name;
            items[i.name].setInventoryObj(go);
        }
    }

    public void Remove(Item i)
    {
        if (items.ContainsKey(i.name))
        {
            items[i.name].Respawn();
        }
    }
}