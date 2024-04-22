using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //funcionalidades basicas de interaccion
    public interface IInteractuable
    {
        bool IsInteractable { get; }

        string TooltipMessage { get; }

        void OnInteract();
    }

