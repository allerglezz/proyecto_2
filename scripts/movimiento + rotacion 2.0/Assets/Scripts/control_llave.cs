using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class control_llave : MonoBehaviour
{
    public bool Dentro = false;
    Renderer rend;
    //se guarda el render de la llave     
    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    //al activar el trigger, si es un jugador
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

    //en cada frame
    void Update()
    {
        //si el jugador esta en el collider y pulsa la e, se recoje la llave y se elimina el render
        if (Dentro && Input.GetKeyUp(KeyCode.E))
        {
            //control_puerta.llave_cogida = true;
            rend.enabled = false;
        }
    }
}
