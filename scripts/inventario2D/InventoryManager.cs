using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
   public static InventoryManager Instace;
   public List<Item> Items = new List<Item>();
   public Item selectedObject;
    public InventoryPanelManager inventoryPanelManager;

   public Transform ItemContent;
   public Transform ItemContent2;
   public GameObject InventoryItem;

   private void Awake()
   {
    int numeroInventario = FindObjectsOfType<InventoryManager>().Length;
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

   public void Add(Item item)
   {
    if(item != null)
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

    public void alquimia(){
        ListItems(true);
    }
    public void notAlquimia(){
        ListItems(false);
    }
   public void ListItems(bool alquimia)
   {
    if (!alquimia){
    foreach(Transform item in ItemContent)
    {
        Destroy(item.gameObject);
    }
    foreach(var item in Items)
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
    }else{

    foreach(Transform item in ItemContent2)
    {
        Destroy(item.gameObject);
    }
    foreach(var item in Items)
    {
        GameObject obj = Instantiate(InventoryItem, ItemContent2);
        var ItemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>(); 
        var ItemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>(); 
        Debug.Log(item);

        ItemName.text = item.ItemName;
        ItemIcon.sprite = item.icon;

        Debug.Log(ItemName.text);
        Debug.Log(ItemIcon.sprite);
    }
    }
   }
   public void ShowInventoryPanel()
    {
        inventoryPanelManager.ShowInventoryPanel(Items, selectedObject);
    }
}
