using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnvasManager : MonoBehaviour
{
    public GameObject MusicSettings;
    public void MostrarMusicSettings()
    {
        if (MusicSettings.activeSelf == false)
        {
            MusicSettings.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            MusicSettings.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
