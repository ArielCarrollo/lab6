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
        }
        else
        {
            MusicSettings.SetActive(false);
        }
    }
}
