using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class activarEnInv : MonoBehaviour
{
    [SerializeField] Button boton;
    [SerializeField] Animacion cajon;

    public void visible(Item item)
    {
        TextMeshProUGUI itemName = boton.transform.Find("ItemName").GetComponent<TextMeshProUGUI>(); // Verifica que el nombre es correcto
        Image itemIcon = boton.transform.Find("ItemIcon").GetComponent<Image>(); // Verifica que el nombre es correcto
        Image interrogationImage = boton.transform.Find("Interrogacion").GetComponent<Image>(); // Verifica que el nombre es correcto

        if (interrogationImage != null)
            interrogationImage.enabled = false;
        if (itemIcon != null)
            itemName.enabled = true;
        cajon.tooltipMessage = "Abrir";
    }
}
