using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOpciones: MonoBehaviour
{
    public AudioMixer audioMixer;
    public void Volumen(float volumen)
    {
        audioMixer.SetFloat("volumen", volumen);
    }
    public void SalirJuego()
    {
        Debug.Log("C salio");
        Application.Quit();
    }
}
