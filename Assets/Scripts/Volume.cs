using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //biblioteca canvas

public class Volume : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f); //guardar posición en donde se encuentra slider luego de cerrar opciones
        AudioListener.volume = slider.value; //sacamos el volumen de nuestro juego para = con el valor de slider
        EstoyMute();
    }
    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        EstoyMute();
    }

    public void EstoyMute() //revisar si estamos en 0 o no para mostrar icono de mute.
    {
        if (sliderValue == 0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }
}
