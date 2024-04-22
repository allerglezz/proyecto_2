using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Interacion Data", menuName = "SistemaDeInteracion/InteracionData")]
public class InteraccionData : ScriptableObject
{
    //para guardar la informacion sobre si es interactuable
    private BaseInteractuable m_interactable;

    //guarda la informacion del objeto interactuable
    public BaseInteractuable Interactable
    {
        get => m_interactable;
        set => m_interactable = value;
    }

    //realiza la interaccion
    public void Interact()
    {
        m_interactable.OnInteract();
        ResetData();
    }

    //comprueba si dos interactuables son iguales
    public bool IsSameInteractable(BaseInteractuable _newInteractable) => m_interactable == _newInteractable;

    //comprueba si el interactuable realmente existe
    public bool IsEmpty() => m_interactable == null;

    //elimina la informacion del interactuable
    public void ResetData() => m_interactable = null;
}
