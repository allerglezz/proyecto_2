using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Progress;

public class InventarioPanelManager : MonoBehaviour
{
    public Transform itemContent;
    public GameObject inventoryItemPrefab;

    public void ShowInventoryPanel(List<Item> items, Item selectedItem)
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject obj = Instantiate(inventoryItemPrefab, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.ItemName;
            itemIcon.sprite = item.icon;

            if (item == selectedItem)
            {
                var selectedObjectText = obj.transform.Find("SelectedObjectText").GetComponent<TextMeshProUGUI>();
                selectedObjectText.text = "Selected";
            }
        }
    }
}
