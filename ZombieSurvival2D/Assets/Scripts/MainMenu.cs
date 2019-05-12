using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("CharacterCreation");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("How2Play");
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
