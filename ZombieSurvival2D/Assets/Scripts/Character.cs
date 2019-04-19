using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private float speed;
    protected Vector2 direction;
    private Animator animator;

     void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        Movement();
    }

    public void Movement()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        AnimationMovement(direction);
    }

    public void AnimationMovement(Vector2 direction)
    {
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }
}
