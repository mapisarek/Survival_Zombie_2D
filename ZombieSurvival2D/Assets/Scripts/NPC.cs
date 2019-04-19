using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        transform.Translate();
    }
}
