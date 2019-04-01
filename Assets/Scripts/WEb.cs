using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using TMPro;

public class WEb : MonoBehaviour
{
    public TextMeshPro tm;
    string kills;

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            webRequest.SetRequestHeader("TRN-Api-Key", "cfcaa723-9d65-44df-85b1-9e9e80b6815c");
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                //Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);
                JSONNode data = JSON.Parse(webRequest.downloadHandler.text);
                Debug.Log(webRequest.downloadHandler.text);
                kills = data["stats"]["p2"]["kills"]["value"].Value;
                Debug.Log(kills);
                int killsValue;
                if(int.TryParse(kills, out killsValue))
                {
                    killsValue = int.Parse(kills);
                    tm.text = kills.ToString();
                    Gamemanager.instance.killsString = kills.ToString();
                }
                Debug.Log("Amount of kills from Ninja = " + killsValue);

            }
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("https://api.fortnitetracker.com/v1/profile/pc/Ninja"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}