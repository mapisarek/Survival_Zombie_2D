using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;

    Items item;

    public void AddItem(Items newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.enabled = true;
        removeButton.interactable = true;
    }
    

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    
 public void OnRemoveButton()
    {
        Inv.instance.Remove(item);
    }

  public void UseItem()
    {
        if (item != null)
        {
            Debug.Log("Using item " + item.name);
            Inv.instance.Remove(item);
           // item.Use();
        }
    }
  
   
}
