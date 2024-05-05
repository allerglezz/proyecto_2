using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class ControladorDeInteracciones : MonoBehaviour
{
    //Los space header son para que se seperan en el inspectoer de unity
    [Space, Header("Data")]
    [SerializeField] private InteraccionInputData interactionInputData = null;
    [SerializeField] private InteraccionData interactionData = null;

    [Space, Header("UI")]
    [SerializeField] private InteraccionIUPanel uiPanel;

    [Space, Header("Ray Settings")]
    [SerializeField] private float rayDistance = 0f;
    [SerializeField] private float raySphereRadius = 0f;
    [SerializeField] private LayerMask interactableLayer = ~0;

    private Camera m_cam;

    private bool m_interacting;
     
    //guardamos la camara
    void Awake()
    {
        m_cam = FindObjectOfType<Camera>();
    }

    //en cada frame miramos si hay un interactuable en el ray y si se puede realizar la interaccion
    void Update()
    {
        CheckForInteractable();
        CheckForInteractableInput();
    }
        
    void CheckForInteractable()
    {
        Ray _ray = new Ray(m_cam.transform.position, m_cam.transform.forward);
        RaycastHit _hitInfo;

        //mira si el rayo golpeo algo
        bool _hitSomething = Physics.SphereCast(_ray, raySphereRadius, out _hitInfo, rayDistance, interactableLayer);
        
        //si el rayo golpeo
        if (_hitSomething)
        {
            //obtenemos la base de interaccion del objeto golpeado
            BaseInteractuable _interactable = _hitInfo.transform.GetComponent<BaseInteractuable>();

            if (_interactable != null)
            {
                //si no hay datos previos de un interactuable
                if (interactionData.IsEmpty())
                {
                    //se guarda el interactuable
                    interactionData.Interactable = _interactable;
                    //se coloca el mensaje
                    uiPanel.SetTooltip(_interactable.TooltipMessage);
                }
                else
                {
                    //en caso de que el interactuable guardado sea el mismo al golpeado
                    if (!interactionData.IsSameInteractable(_interactable))
                    {
                        interactionData.Interactable = _interactable;
                        uiPanel.SetTooltip(_interactable.TooltipMessage);
                    }
                }
            }
        }
        else
        {
            //reseteamos la interfaz
            uiPanel.ResetUI();
            //resetemos los datos de interaccion
            interactionData.ResetData();
        }

        //cambia el color del rayo si miramos un objeto
        Debug.DrawRay(_ray.origin, _ray.direction * rayDistance, _hitSomething ? Color.green : Color.red);
    }

    void CheckForInteractableInput()
    {
        //si no hay datos para interactuar
        if (interactionData.IsEmpty())
        {
            return;
        }
        //si esta clickado
        if (interactionInputData.InteractedClicked)
        {
            m_interacting = true;
        }
        //si se libera el click
        if (interactionInputData.InteractedReleased)
        {
            m_interacting = false;
        }
        //si esta clickado
        if (m_interacting)
        {
            //si no es interactuable
            if (!interactionData.Interactable.IsInteractable)
            {
                return;
            }
            //en caso contrario
            else
            {
                //se realiza la interaccion
                interactionData.Interact();
                m_interacting = false;
            }
        }
    }
}
