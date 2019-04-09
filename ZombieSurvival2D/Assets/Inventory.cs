using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private bool inventoryEnabled;
    public GameObject inventory;
    public GameObject equipment;

    private int allInventorySlots;
    private int enablesInventorySlots;
    private int allEquipmentSlots;
    private int enablesEquipmentSlots;

    private GameObject[] inventorySlot;
    private GameObject[] equipmentSlot;

    public GameObject inventoryHolder;
    public GameObject equipmentHolder;

    void Start()
    {
        allInventorySlots = 104;
        allEquipmentSlots = 5;

        inventorySlot = new GameObject[allInventorySlots];

        for(int i=0; i < allInventorySlots; i++)
        {
            inventorySlot[i] = inventoryHolder.transform.GetChild(i).gameObject;
        }

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
            equipment.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
            equipment.SetActive(false);
        }
    }
}
