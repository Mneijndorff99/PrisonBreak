using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameList
{
    private string[] names;
    private int count;

    public NameList()
    {
        names = new string[1];
        count = 1;
    }

    void AddName(string nameValue)
    {
        if(count < names.Length)
        {
            names[count] = nameValue;
            count++;
        }

        string[] newNames;
        newNames = new string[names.Length + 1];
        for (int i = 0; i < names.Length; i++)
        {
            newNames[i] = names[i];
        }

        newNames[newNames.Length - 1] = nameValue;
        names = newNames;
    }
}
