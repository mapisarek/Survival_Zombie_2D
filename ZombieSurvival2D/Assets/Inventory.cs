using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    private bool inventoryEnabled;
    private bool characterStatsEnabled;
    private bool actionSlotEnabled;
    private bool craftBoxEnabled;
    public static bool GameIsPaused = false;

    public GameObject inventory;
    public GameObject equipment;
    public GameObject actionSlot;
    public GameObject clock;
    public GameObject characterStats;
    public GameObject pauseMenu;
    public GameObject craftBox;


    private int allInventorySlots;
    private int enablesInventorySlots;
    private int allEquipmentSlots;
    private int enablesEquipmentSlots;

    private GameObject[] inventorySlot;
    private GameObject[] equipmentSlot;
    private GameObject[] actionSlots;
    private TextMeshProUGUI nickName;
    private Canvas nicknameCanvas;

    public GameObject inventoryHolder;
    public GameObject equipmentHolder;

    public void Update()
    {
        if (pauseMenu.activeSelf != true)
        {
            toggleInventory();
            toggleActionSlot();
            toggleCharacterStats();
            toggleCraftBox();
        }
        togglePauseMenu();
    }

    public void Start()
    {
        GetUserNickname();
        AccessNicknameCanvas();
    }

    public void toggleCraftBox()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            craftBoxEnabled = !craftBoxEnabled;
        }

        if (craftBoxEnabled == true)
        {
            craftBox.SetActive(true);
        }
        else
        {
            craftBox.SetActive(false);
        }


    }

    private void GetUserNickname()
    {
        nickName = GameObject.Find("NicknameText").GetComponent<TextMeshProUGUI>();
        nickName.text = PlayerPrefs.GetString("Nickname");
    }



    public void toggleInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
        }

        if (inventoryEnabled == true)
        {
            inventory.SetActive(true);
            equipment.SetActive(true);
           // clock.SetActive(false);
            clock.transform.position = new Vector3(clock.transform.position.x, clock.transform.position.y, -2000);
        }
        else
        {
            //clock.SetActive(true);
            inventory.SetActive(false);
            equipment.SetActive(false);

            clock.transform.position = new Vector3(clock.transform.position.x, clock.transform.position.y, 0);
        }


    }

    public void toggleFuncPanels()
    {
        if(inventoryEnabled == false)
        {
            inventory.SetActive(true);
        }
        if (craftBoxEnabled == false)
        {
            craftBox.SetActive(true);
        }
    }

    public void toggleCharacterStats()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            characterStatsEnabled = !characterStatsEnabled;
        }

        if (characterStatsEnabled == true)
        {
            characterStats.SetActive(false);
        }
        else
        {
            characterStats.SetActive(true);
        }
    }

    public void toggleActionSlot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            actionSlotEnabled = !actionSlotEnabled;
        }

        if (actionSlotEnabled == true)
        {
            actionSlot.SetActive(false);
        }
        else
        {
            actionSlot.SetActive(true);
        }

    }

    public void GetChildrenPosition()
    {
        transform.localPosition = transform.GetChild(0).transform.localPosition;
    }

    public void togglePauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){

            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void AccessNicknameCanvas()
    {
        nicknameCanvas = GameObject.Find("NicknameCanvas").GetComponent<Canvas>();
    }

    public void ResumeGame()
    {
        nicknameCanvas.enabled = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void PauseGame()
    {
        nicknameCanvas.enabled = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
    
}
