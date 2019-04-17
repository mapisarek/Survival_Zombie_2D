using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public bool isEnemy = true;
    private float maxHealth = 100;
    private float currentHealth = 100;
    private float maxArmour = 100;
    public float Armor = 100;
    public GameObject charStatsPanel;

    private float maxStamina = 100;
    private float currentStamina = 10;
    private float currentArmour;

    public Texture2D healthTexture;
    public Texture2D armourTexture;
    public Texture2D staminaTexture;
    public Texture2D BackgroundTexture;

    private float posX, posY, mulHP, mulAR, mulSTA;
    private float barWidth;
    private float barHeight;
    private float canRegenerate = 0.0f;
    private float canRegenerateeat = 0.0f;
    float speed = 2;
    float speeds = 4;
    private Rigidbody2D rig;
    public Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        currentArmour = (1 - (1 / (1 + Armor / 100))) * 100;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        if (!Input.GetKey(KeyCode.LeftShift) || currentStamina == 0)
        {
            Vector3 movement = new Vector3(hAxis, vAxis, vAxis) * speed * Time.deltaTime;
            rig.MovePosition(transform.position + movement);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (currentStamina > 0)
            {
                Vector3 movement = new Vector3(hAxis, vAxis, vAxis) * speeds * Time.deltaTime;
                rig.MovePosition(transform.position + movement);
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
                {
                    currentStamina -= 3.0f;
                    currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
                    canRegenerate = 3.0f;
                }
            }
        }

        m_Animator.SetFloat("Poziom", hAxis);
        m_Animator.SetFloat("Pion", vAxis);
    }

    void Update()
    {
        if (canRegenerate > 0.0f)
        {
            canRegenerate -= Time.deltaTime;
            canRegenerateeat -= Time.deltaTime;
        }
        if (canRegenerate <= 0.0f && currentStamina < maxStamina)
        {
            regenerate(ref currentStamina, maxStamina, 0.002f, 0);
        }
        if (currentStamina < maxStamina && Input.GetKey(KeyCode.E))
        {
            regenerate(ref currentStamina, maxStamina, 0.02f, 2);
        }
        
    }

    void Awake()
    {
        barHeight = Screen.height * 0.02f;
        barWidth = barHeight * 17.0f;

    }

    void OnGUI()
    {
        if (charStatsPanel.activeSelf != false)
        {
            posX = 24;
            posY = 37;
            mulHP = 1;
            mulAR = 3.64864f;
            mulSTA = 2.29729f;
        }
        else
        {
            posX = 24;
            posY = 37;
            mulHP = 1;
            mulAR = 2f;
            mulSTA = 1.5f;
        }
        GUI.DrawTexture(new Rect(posX,
                                 posY * mulHP,
                                 maxArmour * barWidth / maxArmour,
                                 barHeight),
                        BackgroundTexture);
        GUI.DrawTexture(new Rect(posX,
                                 posY * mulSTA,
                                 maxHealth * barWidth / maxHealth,
                                 barHeight),
                        BackgroundTexture);

        GUI.DrawTexture(new Rect(posX,
                                 posY * mulAR,
                                 maxStamina * barWidth / maxStamina,
                                 barHeight),
                        BackgroundTexture);



        GUI.DrawTexture(new Rect(posX,
                                 posY * mulAR,
                                 currentArmour * barWidth / maxArmour,
                                 barHeight),
                        armourTexture);
        GUI.DrawTexture(new Rect(posX,
                                 posY * mulHP,
                                 currentHealth * barWidth / maxHealth,
                                 barHeight),
                        healthTexture);

        GUI.DrawTexture(new Rect(posX,
                                 posY * mulSTA,
                                 currentStamina * barWidth / maxStamina,
                                 barHeight),
                        staminaTexture);
    }



    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        // Is this a shot?
        Attack shot = otherCollider.gameObject.GetComponent<Attack>();
        if (shot != null)
        {
            // Avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                // Destroy the shot
                Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
            }
        }
    }
    public void Damage(float damageCount)
    {
        float redukcja = 1 - currentArmour / 100;
        currentHealth -= damageCount * redukcja;

        if (currentHealth <= 0)
        {
            // Dead!
            Destroy(gameObject);
        }
    }

    public void regenerate(ref float currentStat, float maxStat, float reg, float time)
    {
        float timea = time;
        if (time == 0)
        {
            currentStat += maxStat * reg;
            Mathf.Clamp(currentStat, 0, maxStat);
        }
        if (time != 0)
        {

            if (timea >= 0)
            {
                timea -= 0.0001f;
                currentStat += maxStat * reg;
                Mathf.Clamp(currentStat, 0, maxStat);
            }
        }
    }
}