using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventarioManager : MonoBehaviour
{
    public static InventarioManager Instace;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public Dictionary<int, GameObject> ButtonDictionary = new Dictionary<int, GameObject>();


    private void Awake()
    {
            Instace = this;
            GameObject contenido = GameObject.Find("Content");
            ItemContent = contenido.transform;
    }

    private void Update()
    {
        
    }

    void addItemDictionary(Item item)
    {
        GameObject buttonObj = Instantiate(InventoryItem, ItemContent);
        buttonObj.name = "ItemButton_" + item.id;
        ButtonDictionary.Add(item.id, buttonObj);
    }
    public void Add(Item item)
    {
        if (item != null)
        {
            Items.Insert(item.id, item);
            addItemDictionary(item);
            GameObject boton = ButtonDictionary[item.id];
            TextMeshProUGUI itemName = boton.transform.Find("ItemName").GetComponent<TextMeshProUGUI>(); // Verifica que el nombre es correcto
            Image itemIcon = boton.transform.Find("ItemIcon").GetComponent<Image>(); // Verifica que el nombre es correcto
            Image interrogationImage = boton.transform.Find("Interrogacion").GetComponent<Image>(); // Verifica que el nombre es correcto

            if (interrogationImage != null)
                interrogationImage.enabled = false; // Ejemplo de desactivación de una imagen
            if (itemName != null)
                itemName.text = item.ItemName; // Actualiza el texto
            if (itemIcon != null)
                itemIcon.sprite = item.icon; // Actualiza el icono
            Debug.LogWarning("el boton:" + boton);
        }
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var ItemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var ItemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            Debug.Log(item);

            ItemName.text = item.ItemName;
            ItemIcon.sprite = item.icon;

            Debug.Log(ItemName.text);
            Debug.Log(ItemIcon.sprite);
        }
    }

    public bool HasItem(int itemId)
    {
        foreach (Item item in Items)
        {
            if (item.id == itemId)
            {
                return true;
            }
        }
        return false;
    }

}
