using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeInteracciones : MonoBehaviour
{  
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
     
    void Awake()
    {
        m_cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        CheckForInteractable();
        CheckForInteractableInput();
    }
        
    void CheckForInteractable()
    {
        Ray _ray = new Ray(m_cam.transform.position, m_cam.transform.forward);
        RaycastHit _hitInfo;

        bool _hitSomething = Physics.SphereCast(_ray, raySphereRadius, out _hitInfo, rayDistance, interactableLayer);

        if (_hitSomething)
        {
            BaseInteractuable _interactable = _hitInfo.transform.GetComponent<BaseInteractuable>();

            if (_interactable != null)
            {
                if (interactionData.IsEmpty())
                {
                    interactionData.Interactable = _interactable;
                    uiPanel.SetTooltip(_interactable.TooltipMessage);
                }
                else
                {
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
            uiPanel.ResetUI();
            interactionData.ResetData();
        }

        Debug.DrawRay(_ray.origin, _ray.direction * rayDistance, _hitSomething ? Color.green : Color.red);
    }

    void CheckForInteractableInput()
    {
        
        if (interactionData.IsEmpty())
        {
            return;
        }
        
        if (interactionInputData.InteractedClicked)
        {
            m_interacting = true;
        }

        if (interactionInputData.InteractedReleased)
        {
            m_interacting = false;
        }

        if (m_interacting)
        {
            if (!interactionData.Interactable.IsInteractable)
            {
                return;
            }
            else
            {
                interactionData.Interact();
                m_interacting = false;
            }
        }
    }
}
