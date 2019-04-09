using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private bool inventoryEnabled;
    public GameObject inventory;

    private int allSlots;
    private int enablesSlots;
    private GameObject[] slot;

    public GameObject slotHolder;

    void Start()
    {

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if(inventoryEnabled == true)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }
}
