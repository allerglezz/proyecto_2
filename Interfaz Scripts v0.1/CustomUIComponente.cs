using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CustomUIComponent : MonoBehaviour //permite decir este componente lo he hecho customizado as� que lo configuro desde aqu� xd
{
    private void Awake()
    {
        Inicio(); //se inicia, no tiene m�s
    }

    public abstract void Setup(); //hace p�blicas las funciones para que lo dem�s que tiene que configurarse sea llamado desde aqu�
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