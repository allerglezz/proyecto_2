using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteractuable : MonoBehaviour, IInteractuable
{
  //variable que indica si es interactuable
  [SerializeField] private bool isInteractable = true;
  //variable con el texto a mostrar al apuntar al objeto
  [SerializeField] private string tooltipMessage = "interact";
        
   //devuelve si es interactuable
   public bool IsInteractable => isInteractable;
   
    //devuelve el mensaje mostrado
   public string TooltipMessage => tooltipMessage;
   
   //para que se muestre en consola al interectuar (uso exclusivo del desarrolladora)
   public virtual void OnInteract()
   {
     Debug.Log("INTERACTED: " + gameObject.name);
   }
     
}
