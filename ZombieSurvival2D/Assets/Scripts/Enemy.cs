using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : NPC, IEnemy
{
    [SerializeField]
    private CanvasGroup healthGroup;
    [SerializeField]
    public Statistics health;
    [SerializeField]
    private float healthValue;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    public int damage;
    private Collider2D collider;
    private GameObject gameObject;

    public Collider2D Collider2D
    {
        get
        {
            return collider;
        }
        set
        {
            collider = value;
        }
    }

    public GameObject drop;

    private Transform target;
    private IState currentState;
    public Vector3 StartPosition;

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

    public float HealthValue { get => healthValue; set => healthValue = value; }
    public Collider2D Collider { get => collider; set => collider = value; }
    public GameObject GameObject { get => gameObject; set => gameObject = value; }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        InitStats();
        currentState.Update();
        base.Update();
    }

    protected void Awake()
    {
        StartPosition = transform.position;
        ChangeState(new IdleState());
    }

    private void InitStats()
    {
        health.Initialize(healthValue, maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "CircleBox")
        {
            Debug.Log(collision.tag);
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                Debug.Log("Player collision - dmg");
                player.damagePlayer(damage);
            }
        }

    }


    public override void TakeDamage(float damage)
    {
        Direction = Vector3.zero;
        base.TakeDamage(damage);
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;

        currentState.Enter(this);
    }

    public void CheckEnemyStatus()
    {
        if (healthValue <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        healthValue -= damage;
        Debug.Log("Damage taken");
        CheckEnemyStatus();
    }

    public void OnDestroy()
    {
        Instantiate(drop, transform.position, drop.transform.rotation);
    }

}
