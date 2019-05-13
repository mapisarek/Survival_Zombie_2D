using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 1f;
    public Transform interactionTransform;
    Transform player;

    bool isFocus = false;
    bool hasInteracted = false;



    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with " + transform.name);
    }




}
