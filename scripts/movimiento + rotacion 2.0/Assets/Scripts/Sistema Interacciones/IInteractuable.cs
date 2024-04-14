using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public interface IInteractuable
    {
        bool IsInteractable { get; }

        string TooltipMessage { get; }

        void OnInteract();
    }

