using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteractuable : MonoBehaviour, IInteractuable
{
   public Item item;
    
  [SerializeField] private bool isInteractable = true;

  [SerializeField] public string tooltipMessage = "interact";
   public bool IsInteractable => isInteractable;

   public string TooltipMessage => tooltipMessage;
      
   public virtual void OnInteract()
   {
        Debug.Log("INTERACTED: " + gameObject.name);
   }
}
