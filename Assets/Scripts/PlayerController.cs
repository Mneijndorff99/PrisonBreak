using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{
    public Camera camera;
    public GameObject boat;
    public GameObject paddle1;
    public GameObject paddle2;
    public float range = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            Interact();
        }

        if (Input.GetButtonDown("Inventory"))
        {
            SetInventoryVisible(!InventoryUI.instance.gameObject.activeSelf);
        }
    }

    public void SetInventoryVisible(bool value)
    {
        InventoryUI.instance.gameObject.SetActive(value);
        Gamemanager.instance.input.gameObject.SetActive(value);
        GetComponent<FirstPersonController>().enabled = !value;
        Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = value ? Cursor.visible = true : Cursor.visible = false;
    }

    void Interact()
    {
        Ray r = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        int ignorePlayer = ~LayerMask.GetMask("Player");

        if (Physics.Raycast(r, out hit, range, ignorePlayer))
        {

            if(hit.collider.gameObject.tag == "Escape")
            {
                for (int y = 0; y < Inventory.instance.items.Count; y++)
                {
                    if(Inventory.instance.items[y] is RaftItem)
                    {
                        if(Inventory.instance.items[y].name == "Paddle1")
                        {
                            paddle1.SetActive(true);
                            Inventory.instance.items.Remove(Inventory.instance.items[y]);
                        }
                        else if (Inventory.instance.items[y].name == "Paddle2")
                        {
                            paddle2.SetActive(true);
                            Inventory.instance.items.Remove(Inventory.instance.items[y]);
                        }
                        else if (Inventory.instance.items[y].name == "BoatPart")
                        {
                            boat.SetActive(true);
                            Inventory.instance.items.Remove(Inventory.instance.items[y]);
                        }
                    }
                    else
                    {
                        StartCoroutine(TypeText.instance.ShowDialogText("You have to find al the raft parts to escape this prison!"));
                    }
                }
            }
            //Debug.Log("Hit " + hit.collider.gameObject.name);
            IInteract i = hit.collider.gameObject.GetComponent<IInteract>();
            if (i != null)
            {
                i.Action();
            }
        }
    }

    
}
