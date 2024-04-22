using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//heredas base de interaccion
public class Destruir : BaseInteractuable
    {
        //sobrescribo el metodo de interaccion
        public override void OnInteract()
        {
            base.OnInteract();

            Destroy(gameObject);
        }
    }

