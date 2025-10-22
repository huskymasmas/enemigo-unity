using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{

    public GameObject menu1, menopciones;
   
  
    public Slider sliderVolumen;
    public Toggle togglePantallaCompleta;
    public TMP_Dropdown dropdownResolucion;
    public TMP_Dropdown dropdownCalidad;

    [Header("Audio")]
    public AudioSource audioFuente;

    private Resolution[] resoluciones;
    public void juagar()
  {
        SceneManager.LoadScene("SampleScene");
  }

  public void opciones()
  {
        menu1.SetActive(false);
        menopciones.SetActive(true);
        // Cargar Volumen
        float volumenGuardado = PlayerPrefs.GetFloat("Volumen", 1f);
        sliderVolumen.value = volumenGuardado;
        audioFuente.volume = volumenGuardado;

        // Cargar Pantalla Completa
        bool pantallaCompletaGuardada = PlayerPrefs.GetInt("PantallaCompleta", 1) == 1;
        togglePantallaCompleta.isOn = pantallaCompletaGuardada;
        Screen.fullScreen = pantallaCompletaGuardada;

        // Cargar Resoluciones
        resoluciones = Screen.resolutions;
        dropdownResolucion.ClearOptions();
        int indiceActual = 0;
        for (int i = 0; i < resoluciones.Length; i++)
        {
            dropdownResolucion.options.Add(new TMP_Dropdown.OptionData(resoluciones[i].width + " x " + resoluciones[i].height));
            if (resoluciones[i].width == Screen.currentResolution.width &&
                resoluciones[i].height == Screen.currentResolution.height)
            {
                indiceActual = i;
            }
        }
        int resGuardada = PlayerPrefs.GetInt("Resolucion", indiceActual);
        dropdownResolucion.value = resGuardada;
        dropdownResolucion.RefreshShownValue();
        AplicarResolucion(resGuardada);

        // Cargar Calidad Gráfica
        dropdownCalidad.ClearOptions();
        dropdownCalidad.AddOptions(new List<string>(QualitySettings.names));
        int calidadGuardada = PlayerPrefs.GetInt("Calidad", QualitySettings.GetQualityLevel());
        dropdownCalidad.value = calidadGuardada;
        dropdownCalidad.RefreshShownValue();
        QualitySettings.SetQualityLevel(calidadGuardada);

        // Conectar eventos dinámicos
        sliderVolumen.onValueChanged.AddListener(delegate { AjustarVolumen(); });
        togglePantallaCompleta.onValueChanged.AddListener(delegate { CambiarPantallaCompleta(); });
        dropdownResolucion.onValueChanged.AddListener(delegate { CambiarResolucion(); });
        dropdownCalidad.onValueChanged.AddListener(delegate { CambiarCalidad(); });

    }

    public void AjustarVolumen()
    {
        audioFuente.volume = sliderVolumen.value;
        PlayerPrefs.SetFloat("Volumen", sliderVolumen.value);
        Debug.Log("Volumen actual: " + audioFuente.volume);
    }
    public void CambiarPantallaCompleta()
    {
        Screen.fullScreen = togglePantallaCompleta.isOn;
        PlayerPrefs.SetInt("PantallaCompleta", togglePantallaCompleta.isOn ? 1 : 0);
        Debug.Log("Pantalla completa: " + Screen.fullScreen);
    }


    public void CambiarResolucion()
    {
        int index = dropdownResolucion.value;
        Resolution res = resoluciones[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        PlayerPrefs.SetInt("Resolucion", index);
        Debug.Log("Resolución aplicada: " + res.width + " x " + res.height);
    }

    private void AplicarResolucion(int index)
    {
        Resolution res = resoluciones[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

   
    public void CambiarCalidad()
    {
        int index = dropdownCalidad.value;
        QualitySettings.SetQualityLevel(index);
        PlayerPrefs.SetInt("Calidad", index);
        Debug.Log("Calidad aplicada: " + QualitySettings.names[index]);
    }



   
    public void salir()
  {
        Application.Quit();


  }
  public void men()
    {
        menu1.SetActive(true);
        menopciones.SetActive(false);
    }
}
