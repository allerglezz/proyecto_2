using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events; //para comprobar si se ha clicado

public class ScriptBoton : CustomUIComponent //es un componente custom así que se inicializa/configura desde CustomUIComponent
{
    public TemasSO temas; //para aplicar tema prehecho (util para diferenciar cosas a simple vista)
    public Estilo estilo; //same
    public UnityEvent alClicar; //funcion de hacer clic

    private Button boton;
    private TextMeshProUGUI textoBoton;

    public override void Setup()
    {
        boton = GetComponentInChildren<Button>(); //como va en el padre, obtiene el botón hijo
        textoBoton = GetComponent<TextMeshProUGUI>(); //obtiene el texto del hijo
    }

    public override void Configurar() //configura los temas/estilo visual
    {
        ColorBlock cb = boton.colors;
        cb.normalColor = temas.GetBackgroundColor(estilo);
        boton.colors = cb;

        textoBoton.color = temas.GetTextColor(estilo);
    }

    public void AlClicar() //para hacer clic al botón ;)
    {
        alClicar.Invoke();
    }
}
