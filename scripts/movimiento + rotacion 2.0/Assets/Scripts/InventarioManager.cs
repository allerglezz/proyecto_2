using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventarioManager : MonoBehaviour
{
    public static InventarioManager Instace;
    public List<Item> Items = new List<Item>();
    public Item selectedObject;
    public InventarioPanelManager inventoryPanelManager;

    public Transform ItemContent;
    public GameObject InventoryItem;
    public GameObject inventario;

    private void Awake()
    {
        int numeroInventario = FindObjectsOfType<InventarioManager>().Length;
        if (numeroInventario > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
            Instace = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inventario.SetActive(!inventario.activeSelf);
        }
    }
    public void Add(Item item)
    {
        if (item != null)
            Items.Add(item);
    }

    public void SetContent()
    {
        GameObject contenido = GameObject.Find("Content");
        ItemContent = contenido.transform;
        Debug.Log("Cont" + contenido.ToString());

    }


    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems(bool alquimia)
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

    public void ShowInventoryPanel()
    {
        inventoryPanelManager.ShowInventoryPanel(Items, selectedObject);
    }
}
