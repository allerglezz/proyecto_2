using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : BaseInteractuable
    {
    [SerializeField] activarEnInv inventario;
        //se sobrescribe onInteract de baseInteractuable para destruir el objeto
        public override void OnInteract()
        {
            base.OnInteract();
            InventarioManager.Instace.Add(item);
            inventario.visible(item);
            Destroy(gameObject);
        }
    }