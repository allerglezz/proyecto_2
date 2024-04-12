using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CustomUIComponent : MonoBehaviour //permite decir este componente lo he hecho customizado así que lo configuro desde aquí xd
{
    private void Awake()
    {
        Inicio(); //se inicia, no tiene más
    }

    public abstract void Setup(); //hace públicas las funciones para que lo demás que tiene que configurarse sea llamado desde aquí
    public abstract void Configurar();

    private void Inicio()
    {
        Setup();
        Configurar();
    }

    private void OnValidate() //comprueba si se ha cambiado algo desde unity y configura todos los custom components
    {
        Inicio();
    }
}