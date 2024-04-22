using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteraccionIUPanel : MonoBehaviour
{
    //para guarda el texto a mostrar
    [SerializeField] private TextMeshProUGUI tooltipText;

    //guarda el texto (tooltip)
    public void SetTooltip(string tooltip)
    {
        tooltipText.SetText(tooltip);
    }

    //borra el texto guardado
    public void ResetUI()
    {
        tooltipText.SetText("");
    }
}
