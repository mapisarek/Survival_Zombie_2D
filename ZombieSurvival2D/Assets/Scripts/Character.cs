using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private float speed;
    protected Vector2 direction;

     void Start()
    {
        
    }

    protected virtual void Update()
    {
        Movement();
    }

    public void Movement()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
