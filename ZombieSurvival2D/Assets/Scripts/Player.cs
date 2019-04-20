using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    private Statistics health;
    [SerializeField]
    private float healthValue;
    [SerializeField]
    private float maxHealth;

    protected override void Start()
    {
        health.Initialize(healthValue,maxHealth);
        base.Start();
    }

    protected override void Update()
    {
        InputKeys();
        health.CurrentValue = 100;
        base.Update();
    }

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
            direction += Vector2.right;
        }
    }
    
}
