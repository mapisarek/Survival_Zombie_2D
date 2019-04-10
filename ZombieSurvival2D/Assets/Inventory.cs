using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    private bool inventoryEnabled;
    private bool characterStatsEnabled;
    private bool actionSlotEnabled;
    public GameObject inventory;
    public GameObject equipment;
    public GameObject actionSlot;
    public GameObject clock;
    public GameObject characterStats;

    private int allInventorySlots;
    private int enablesInventorySlots;
    private int allEquipmentSlots;
    private int enablesEquipmentSlots;

    private GameObject[] inventorySlot;
    private GameObject[] equipmentSlot;
    private GameObject[] actionSlots;

    public GameObject inventoryHolder;
    public GameObject equipmentHolder;

    void Start()
    {
        getActionSlotElements();
    }

    public void Update()
    {
        toggleInventory();
        toggleActionSlot();
    }

    public void setActiveSlotInActionSlot()
    {
        
    }

    public void getActionSlotElements()
    {
        for(int i = 0; i < actionSlot.transform.childCount; i++)
        {
            actionSlots[i] = actionSlot.transform.GetChild(i).gameObject;
        }

    }

    public void toggleInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled == true)
        {
            inventory.SetActive(true);
            equipment.SetActive(true);
            clock.SetActive(false);
        }
        else
        {
            clock.SetActive(true);
            inventory.SetActive(false);
            equipment.SetActive(false);
        }


    }

    public void toggleCharacterStats()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            characterStatsEnabled = !characterStatsEnabled;
        }

        if (characterStats == true)
        {
            characterStats.SetActive(false);
        }
        else
        {
            characterStats.SetActive(true);
        }
    }

    public void toggleActionSlot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            actionSlotEnabled = !actionSlotEnabled;
        }

        if (actionSlotEnabled == true)
        {
            actionSlot.SetActive(false);
        }
        else
        {
            actionSlot.SetActive(true);
        }

    }

}
