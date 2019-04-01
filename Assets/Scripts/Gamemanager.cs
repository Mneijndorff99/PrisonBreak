using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;
    public string killsString;
    public int totalRaftparts = 0;
    public GameObject door;
    public TMP_InputField input;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(input.text == killsString)
            {
                door.GetComponent<Door>().open = true;
            }
        }
    }
}
