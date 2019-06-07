using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    private CanvasGroup SettingCanvas;
    public Canvas SettingsCanvas;

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadVolumeSettings()
    {
        gameObject.transform.Find("SettingCanvas").gameObject.SetActive(true);
    }
}
