using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{

    public Items item;

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    public void PickUp()
    {
        Debug.Log("Picking up item " + item.name);
        bool wasPickedUp = Inv.instance.Add(item);

        if(wasPickedUp)
        Destroy(gameObject);
    }
}
