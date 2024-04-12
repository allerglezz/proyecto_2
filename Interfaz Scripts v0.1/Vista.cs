using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vista : CustomUIComponent //se controla desde CustomUIComponente
{
    public VistaSO verDatos;

    public GameObject CajaArriba; //divide la pantalla en varias cajas (lo he hecho de prueba no creo que haga falta)
    public GameObject CajaCentro;
    public GameObject CajaAbajo;

    private Image imagenArriba;
    private Image imagenCentro;
    private Image imagenAbajo;

    private VerticalLayoutGroup verticalLayoutGroup; //hace que se divida, nothing importante para nuestro caso, aunque podría ser útil

    public override void Setup() //cosas varias para establecer la vista
    {
        verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
        imagenArriba = CajaArriba.GetComponent<Image>();
        imagenCentro = CajaCentro.GetComponent<Image>();
        imagenAbajo = CajaAbajo.GetComponent<Image>();
    }

    public override void Configurar() //configurar tamaños/temas de las divisiones
    {
        verticalLayoutGroup.padding = verDatos.padding;
        verticalLayoutGroup.spacing = verDatos.spacing;

        imagenArriba.color = verDatos.temas.fondo_primario;
        imagenCentro.color = verDatos.temas.fondo_secundario;
        imagenAbajo.color = verDatos.temas.fondo_terciario;

    }
}
