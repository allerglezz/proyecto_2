using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteraccionInputData", menuName = "SistemaDeInteracion/InputData")]
public class InteraccionInputData : ScriptableObject
{
    //cuando haces click
    public bool m_interactedClicked = false;
    //cuando sueltas el click
    private bool m_interactedRelease = false;

    //guardar el valor al clickar
    public bool InteractedClicked
    {
        get => m_interactedClicked;
        set => m_interactedClicked = value;
    }

    //guarda el valor al soltar el click
    public bool InteractedReleased
    {
        get => m_interactedRelease;
        set => m_interactedRelease = value;
    }

    //los devuelves a false como estaba al principio
    public void ResetInput()
    {
        m_interactedClicked = false;
        m_interactedRelease = false;
    }
}
