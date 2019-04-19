using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector2 direction;

    void Start()
    {
        
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    /*
    private void InputKeys()
    {
        direction = Vector2.zero;

        if(Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.left;
        }
    }
    */
}
