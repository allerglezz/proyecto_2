using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_puerta : MonoBehaviour
{
    Animator anim;
    public bool Dentro = false;
    public bool Puerta = false;
    //public static bool llave_cogida = false;
    //se obitene el animator
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    //al entrar al collider si es un jugador
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Dentro = true;
        }
    }

    //al salir del collider si es un jugador
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Dentro = false;
        }
    }

    // en cada frame
    void Update()
    {
        //si esta dentro se presiona la e y la llave esta en el inventario
        if (Dentro && Input.GetKeyUp(KeyCode.E)) 
        {
            //se cambia el valor
            Puerta = !Puerta;
        }
        //si Puerta es true se abre
        if(Puerta)
        {
            anim.SetBool("ABIERTA", true);
        }
        //en caso contrario se cierra
        else
        {
            anim.SetBool("ABIERTA", false);
        }
    }
}
