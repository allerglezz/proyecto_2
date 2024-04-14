using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteraccionIUPanel : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private TextMeshProUGUI tooltipText;

    public void SetTooltip(string tooltip)
    {
        tooltipText.SetText(tooltip);
    }

    public void ResetUI()
    {
        tooltipText.SetText("");
    }
}
