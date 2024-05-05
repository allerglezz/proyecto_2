using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animacion : BaseInteractuable
{
    private Animator anim;
    private bool abierto = false;
    [SerializeField] int llave_requerida;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void OnInteract()
    {
        base.OnInteract();
        if(InventarioManager.Instace.HasItem(llave_requerida))
        {
            abierto = !abierto; // Cambia el estado primero
            anim.SetBool("ABIERTA", abierto); // Actúa según el nuevo estado
        }
    }
}
