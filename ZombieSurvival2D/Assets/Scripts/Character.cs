using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour, ICharacter
{
    [SerializeField]
    private float speed;
    private Vector3 direction;
    private Animator animator;
    private new Rigidbody2D rigidbody2D;
    protected bool IsAttacking = false;

    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }

    public Vector3 Direction
    {
        get
        {
            return direction;
        }

        set
        {
            direction = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        HandleLayer();
    }

    private void FixedUpdate()
    {
        Movement();
    }


    public void Movement()
    {
        if (this.gameObject.tag != "Enemy")
            rigidbody2D.velocity = direction.normalized * speed;

    }

    public void HandleLayer()
    {
        if (IsMoving)
        {
            AnimationMovement(direction);
        }
        else if (IsAttacking)
        {
            ActivateLayer("AttackLayer");
        }
        else
        {
            ActivateLayer("IdleLayer");
        }
    }

    public void AnimationMovement(Vector3 direction)
    {
        ActivateLayer("WalkLayer");

        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }


    public void ActivateLayer(string layerName)
    {
        for (int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }

        animator.SetLayerWeight(animator.GetLayerIndex(layerName), 1);

    }

    public virtual void TakeDamage(float damage)
    {
        //health.CurrentValue -= damage;
        //if(health.CurrentValue <= 0)
        //{
        //   animator.SetTrigger("die");
        //}
    }

}
