using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    private bool inventoryEnabled;
    private bool characterStatsEnabled;
    private bool actionSlotEnabled;
    public static bool GameIsPaused = false;

    public GameObject inventory;
    public GameObject equipment;
    public GameObject actionSlot;
    public GameObject clock;
    public GameObject characterStats;
    public GameObject pauseMenu;

    private int allInventorySlots;
    private int enablesInventorySlots;
    private int allEquipmentSlots;
    private int enablesEquipmentSlots;

    private GameObject[] inventorySlot;
    private GameObject[] equipmentSlot;
    private GameObject[] actionSlots;

    public GameObject inventoryHolder;
    public GameObject equipmentHolder;

    public void Update()
    {
        toggleInventory();
        toggleActionSlot();
        toggleCharacterStats();
        togglePauseMenu();
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
            clock.SetActive(false);
        }
        else
        {
            clock.SetActive(true);
            inventory.SetActive(false);
            equipment.SetActive(false);
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

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
    
}
