using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteractuable : MonoBehaviour, IInteractuable
{

  [SerializeField] private bool isInteractable = true;

  [SerializeField] private string tooltipMessage = "interact";
        
   public bool IsInteractable => isInteractable;

   public string TooltipMessage => tooltipMessage;
      
   public virtual void OnInteract()
   {
     Debug.Log("INTERACTED: " + gameObject.name);
   }
     
}
