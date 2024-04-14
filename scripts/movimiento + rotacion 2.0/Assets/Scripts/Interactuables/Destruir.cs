using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : BaseInteractuable
    {

        public override void OnInteract()
        {
            base.OnInteract();

            Destroy(gameObject);
        }
    }

