using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    protected Enemy parent;

    protected override void Start()
    {
        
    }

    protected override void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.Target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.Target = null;
        }
    }

}
