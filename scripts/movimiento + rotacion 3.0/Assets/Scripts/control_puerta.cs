using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_puerta : MonoBehaviour
{
    Animator anim;
    public bool Dentro = false;
    public bool Puerta = false;
    public static bool llave_cogida = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            Dentro = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Dentro = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Dentro && Input.GetKeyUp(KeyCode.E) && llave_cogida) 
        {
            Puerta = !Puerta;
        }
        if(Puerta)
        {
            anim.SetBool("abierta", true);
        }
        else
        {
            anim.SetBool("abierta", false);
        }
    }
}
