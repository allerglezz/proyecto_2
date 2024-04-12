using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CustomUI/TemasSO", fileName = "Temas")] //hace un menú para elegir el estilo
public class TemasSO : ScriptableObject //hace la lista de los temas para mostrar/editar desde Unity
{
    [Header("Primario")] //distintos estilos, cambia color de fondo y texto
    public Color fondo_primario;
    public Color texto_primario;

    [Header("Secundario")]
    public Color fondo_secundario;
    public Color texto_secundario;

    [Header("Terciario")]
    public Color fondo_terciario;
    public Color texto_terciario;

    [Header("Cuaternario")]
    public Color fondo_cuaternario;
    public Color texto_cuaternario;

    [Header("Otro")]
    public Color deshabilitado;

    public Color GetBackgroundColor(Estilo estilo) //seleccionar color del fondo
    {
        if (estilo == Estilo.Primario)
        {
            return fondo_primario;
        } else if ( estilo == Estilo.Secundario)
        {
            return fondo_secundario;
        } else if (estilo == Estilo.Terciario)
        {
            return fondo_terciario;
        } else if (estilo == Estilo.Cuaternario)
        {
            return fondo_cuaternario;
        }
        return deshabilitado;
    }
    public Color GetTextColor(Estilo estilo) //seleccionar color del texto
    {
        if (estilo == Estilo.Primario)
        {
            return texto_primario;
        } else if (estilo == Estilo.Secundario)
        {
            return texto_secundario;
        } else if (estilo == Estilo.Terciario)
        {
            return texto_terciario;
        } else if (estilo == Estilo.Cuaternario)
        {
            return texto_cuaternario;
        }

        return deshabilitado;
    }

}
