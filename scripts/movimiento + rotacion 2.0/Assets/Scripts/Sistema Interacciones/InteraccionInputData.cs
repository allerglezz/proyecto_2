using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteraccionInputData", menuName = "SistemaDeInteracion/InputData")]
public class InteraccionInputData : ScriptableObject
{
    public bool m_interactedClicked = false;
    private bool m_interactedRelease = false;

    public bool InteractedClicked
    {
        get => m_interactedClicked;
        set => m_interactedClicked = value;
    }

    public bool InteractedReleased
    {
        get => m_interactedRelease;
        set => m_interactedRelease = value;
    }

    public void ResetInput()
    {
        m_interactedClicked = false;
        m_interactedRelease = false;
    }
}
