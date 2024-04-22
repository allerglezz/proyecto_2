using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class control_llave : MonoBehaviour
{
    public bool Dentro = false;
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
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
        if (Dentro && Input.GetKeyUp(KeyCode.E))
        {
            control_puerta.llave_cogida = true;
            rend.enabled = false;
        }
    }
}
