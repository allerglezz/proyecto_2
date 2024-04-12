using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Texto : CustomUIComponent { //texto customizable desde Unity, se controla con CustomUIComponente

    public TextoSO datosTexto; //los datos que recibe
    public Estilo estilo;

    private TextMeshProUGUI textMeshProUGUI;


    public override void Setup()
    {
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>(); //recibe el texto del hijo
    }

    public override void Configurar() //configura los temas/estilos visuales
    {
        textMeshProUGUI.color = datosTexto.temas.GetTextColor(estilo);
        textMeshProUGUI.font = datosTexto.fuente;
        textMeshProUGUI.fontSize = datosTexto.tamano;
    }

}

