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


}
