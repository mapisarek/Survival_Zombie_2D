using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC
{

    [SerializeField]
    private CanvasGroup healthGroup;
    private Transform target;
    private IState currentState;
    public Vector3 StartPosition;

    [SerializeField]
    public Statistics health;
    [SerializeField]
    private float healthValue;
    [SerializeField]
    private float maxHealth;


    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        currentState.Update();
        base.Update();
    }

    protected void Awake()
    {
        StartPosition = transform.position;
        ChangeState(new IdleState());
    }


    public override void TakeDamage(float damage)
    {
        Direction = Vector3.zero;
        base.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        healthValue -= damage;
        Debug.Log("Damage taken");
        CheckEnemyStatus();
    }

    private void CheckEnemyStatus()
    {
        if (healthValue <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeState(IState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;

        currentState.Enter(this);
    }



}
