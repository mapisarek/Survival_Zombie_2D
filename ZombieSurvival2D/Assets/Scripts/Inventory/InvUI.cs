using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvUI : MonoBehaviour
{
    public Transform itemsParent;
    Inv inventory;
    InventorySlot[] slots;

     void Start()
    {
        inventory = Inv.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }
void Update()
    {
        
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
    
}
