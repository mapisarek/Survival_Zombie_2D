﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    [SerializeField]
    private float speed;

    void Start()
    {
        
    }

    void Update()
    {
        Movement();
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