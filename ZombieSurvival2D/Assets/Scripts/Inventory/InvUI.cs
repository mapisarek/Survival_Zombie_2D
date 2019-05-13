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

    
}
