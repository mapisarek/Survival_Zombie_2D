using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField]
    protected Statistics health;
    [SerializeField]
    private float healthValue;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    protected Statistics stamina;
    [SerializeField]
    private float staminaValue;
    [SerializeField]
    private float maxStamina;

    [SerializeField]
    protected Statistics armor;
    [SerializeField]
    private float armorValue;
    [SerializeField]
    private float maxArmor;

    private float basicSpeed;
    private float runSpeed;
	private float Timer;
	private bool isRunning;


    [SerializeField]
    private float boost;
    [SerializeField]
    private float staminaWaste;
    [SerializeField]
    private float staminaRegeneration;
  
	
    protected override void Start()
    {
        setupVariables();
        base.Start();
    }

    private void InitializeStatsValues()
    {
        health.Initialize(healthValue, maxHealth);
        stamina.Initialize(staminaValue, maxStamina);
        armor.Initialize(armorValue, maxArmor);
    }

    private void setupVariables()
    {
        staminaRegeneration = 2;
        staminaWaste = 15;
        boost = 2;
        basicSpeed = Speed;
        runSpeed = basicSpeed * boost;
    }
        
    protected override void Update()
    {
        InitializeStatsValues();
        Timer += Time.deltaTime;
		basicSetup();
        InputKeys();
        //health.CurrentValue = 100;
        base.Update();
    }

    private void InputKeys()
    {
        Direction = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            Direction += Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Direction += Vector3.down; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            Direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(staminaValue > 0)
			isRunning = true;
            if (staminaValue < 0)
                isRunning = false;
        }
		else{
			isRunning = false;
		}
        
    }
	
	private void basicSetup(){
		if(!isRunning){
			Speed = basicSpeed;
			staminaRegen();
		}
		if(isRunning){
		Speed = runSpeed;
        if(IsMoving)
        burnStamina();
		}
	}
	
	private void burnStamina(){
	 if(staminaValue > 0)
            {
            staminaValue -= Time.deltaTime * staminaWaste;
            Timer = 0;
			}
	}
	
    public void staminaRegen()
    {
        if(Timer > 5 && staminaValue <= maxStamina)
        {
            staminaValue += Time.deltaTime * staminaRegeneration;
        }
    }
		
}
