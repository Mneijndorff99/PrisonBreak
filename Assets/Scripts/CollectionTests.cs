using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionTests : MonoBehaviour
{
    private string[] names;
    public List<int> scores;
    // Start is called before the first frame update
    void Start()
    {
        names = new string[2];
        names[0] = "David";
        names[1] = "Bea";

        for (int i = 0; i < names.Length; i++)
        {
            Debug.Log(names[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AddName("Sophia");
            ShowNames();
        }
    }

    void AddName(string nameValue)
    {
        string[] newNames;
        newNames = new string[names.Length + 1];
        for (int i = 0; i < names.Length; i++)
        {
            newNames[i] = names[i];
        }

        newNames[newNames.Length - 1] = nameValue;
        names = newNames;
    }

    void ShowNames()
    {
        for (int i = 0; i < names.Length; i++)
        {
            Debug.Log(names[i]);
        }
    }
}
