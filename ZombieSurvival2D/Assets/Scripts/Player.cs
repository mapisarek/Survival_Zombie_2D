using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    Camera cam;
    PlayerMovementController playerMovement;

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

    public Interactable focus;

    public float HealthValue
    {
        get
        {
            return healthValue;
        }

        set
        {
            healthValue = value;
        }
    }

    public float ArmorValue
    {
        get
        {
            return armorValue;
        }

        set
        {
            armorValue = value;
        }
    }

    public float StaminaValue
    {
        get
        {
            return staminaValue;
        }

        set
        {
            staminaValue = value;
        }
    }

    public Camera Cam { get => cam; set => cam = value; }
    public bool IsRunning { get => isRunning; set => isRunning = value; }

    private void Awake()
    {
        playerMovement = new PlayerMovementController();
    }

    protected override void Start()
    {
        cam = Camera.main;
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
        InputActionKeys();
        base.Update();
    }

    public void InputKeys()
    {
        Direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
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
            if (StaminaValue > 0)
                IsRunning = true;
            if (StaminaValue < 0)
                IsRunning = false;
        }
        else
        {
            IsRunning = false;
        }
    }

    private void InputActionKeys()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            RemoveFocus();
        }
    }


    // Set our focus to a new focus
    void SetFocus(Interactable newFocus)
    {
        // If our focus has changed
        if (newFocus != focus)
        {
            // Defocus the old one
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;   // Set our new focus
        }

        newFocus.OnFocused(transform);
    }


    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
    }

    private void basicSetup()
    {
        if (!isRunning)
        {
            Speed = basicSpeed;
            staminaRegen();
        }
        if (isRunning)
        {
            Speed = runSpeed;
            if (IsMoving)
                burnStamina();
        }
    }

    private void burnStamina()
    {
        if (staminaValue > 0)
        {
            staminaValue -= Time.deltaTime * staminaWaste;
            Timer = 0;
        }
    }

    public void staminaRegen()
    {
        if (Timer > 5 && staminaValue <= maxStamina)
        {
            staminaValue += Time.deltaTime * staminaRegeneration;
        }
    }

    public void damagePlayer(int damage)
    {
        healthValue -= damage;
        if (healthValue <= 0)
            GameObject.Destroy(this);
    }

}

public class PlayerMovementController
{
    public void InputKeys(ICharacter character, IPlayer player,
        bool w, bool s, bool a, bool d, bool shift)
    {
        //direction = Vector3.zero;

        if (w)
        {
            character.Direction += Vector3.up;
        }
        if (a)
        {
            character.Direction += Vector3.left;
        }
        if (s)
        {
            character.Direction += Vector3.down;
        }
        if (d)
        {
            character.Direction += Vector3.right;
        }
        if (shift)
        {
            if (player.StaminaValue > 0)
                player.IsRunning = true;
            if (player.StaminaValue < 0)
                player.IsRunning = false;
        }
        else
        {
            player.IsRunning = false;
        }
    }
}
