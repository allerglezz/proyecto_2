using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeInteracciones : MonoBehaviour
{  
    //space,header("") es para separar las variables en al interfaz de unity. ver Player
    [Space, Header("Data")]
    //se guarda si es interactuable o no
    [SerializeField] private InteraccionInputData interactionInputData = null;
    //se guarda la clase para comprobar informacion sobre el objeto y realizar la interaccion
    [SerializeField] private InteraccionData interactionData = null;

    [Space, Header("UI")]
    //texto que se muestra al apuntar al objeto
    [SerializeField] private InteraccionIUPanel uiPanel;

    [Space, Header("Ray Settings")]
    //ajustes del rayo
    [SerializeField] private float rayDistance = 0f;
    [SerializeField] private float raySphereRadius = 0f;
    [SerializeField] private LayerMask interactableLayer = ~0;

    //camara
    private Camera m_cam;

    //si se puede interactuar o no
    private bool m_interacting;
     
    //guarda la camara
    void Awake()
    {
        m_cam = FindObjectOfType<Camera>();
    }

    //en cada frame, miras el rayo a que apunta y mira si se interactua con el objeto
    void Update()
    {
        CheckForInteractable();
        CheckForInteractableInput();
    }
        
    void CheckForInteractable()
    {
        //coges posicion del rayo/camara
        Ray _ray = new Ray(m_cam.transform.position, m_cam.transform.forward);
        //para guardar donde impacta el rayo
        RaycastHit _hitInfo;

        //comprueba si el rayo toca algo
        bool _hitSomething = Physics.SphereCast(_ray, raySphereRadius, out _hitInfo, rayDistance, interactableLayer);

        //si el rayo toca algo
        if (_hitSomething)
        {
            //creas la base de interaccion
            BaseInteractuable _interactable = _hitInfo.transform.GetComponent<BaseInteractuable>();

            //si es interactuable
            if (_interactable != null)
            {
                //si no hay aun datos de interacion
                if (interactionData.IsEmpty())
                {
                    //guarda esos datos de interaccion
                    interactionData.Interactable = _interactable;
                    //guarda el mensaje a mostrar
                    uiPanel.SetTooltip(_interactable.TooltipMessage);
                }
                //si ya hay datos de interaccion
                else
                {
                    //si no son el mismo dato de interaccion
                    if (!interactionData.IsSameInteractable(_interactable))
                    {
                        //lo mismo que si no hay datos aun
                        interactionData.Interactable = _interactable;
                        uiPanel.SetTooltip(_interactable.TooltipMessage);
                    }
                }
            }
        }
        //si el rayo no toca nada
        else
        {
            //reseteas la interfaz
            uiPanel.ResetUI();
            //reseteas los datos de interaccion
            interactionData.ResetData();
        }

        //cuando apunta a nada y/u objeto no interactuable el rayo sera rojo, si el objeto es interactuable saldra verde
        Debug.DrawRay(_ray.origin, _ray.direction * rayDistance, _hitSomething ? Color.green : Color.red);
    }

    void CheckForInteractableInput()
    {
        //si la informacion de interaccion esta vacio no haces nada
        if (interactionData.IsEmpty())
        {
            return;
        }
        
        //si esta clickado
        if (interactionInputData.InteractedClicked)
        {
            m_interacting = true;
        }

        //si se suelta el click
        if (interactionInputData.InteractedReleased)
        {
            m_interacting = false;
        }

        //mientras este clickado
        if (m_interacting)
        {
            //si no es interactuable no haces nada
            if (!interactionData.Interactable.IsInteractable)
            {
                return;
            }
            //si es interactuable
            else
            {
                //se realiza la interaccion
                interactionData.Interact();
                m_interacting = false;
            }
        }
    }
}
