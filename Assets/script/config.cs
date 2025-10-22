using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class config : MonoBehaviour
{
    public AudioSource audioFuente;
    void Start()
    {
      
        audioFuente.volume = PlayerPrefs.GetFloat("Volumen", 1f);

        
        Screen.fullScreen = PlayerPrefs.GetInt("PantallaCompleta", 1) == 1;

       
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Calidad", QualitySettings.GetQualityLevel()));

       
        int resIndex = PlayerPrefs.GetInt("Resolucion", 0);
        Resolution res = Screen.resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

}
