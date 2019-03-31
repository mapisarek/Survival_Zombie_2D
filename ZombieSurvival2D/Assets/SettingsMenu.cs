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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void LoadVolumeSettings()
    {
        gameObject.transform.Find("SettingCanvas").gameObject.SetActive(true);
    }
}
