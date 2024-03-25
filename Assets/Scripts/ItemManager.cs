using UnityEngine;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;

    public static ItemManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ItemManager>();

                // If an instance is still not found, create a new GameObject and add the ItemManager script to it
                if (instance == null)
                {
                    GameObject obj = new GameObject("ItemManager");
                    instance = obj.AddComponent<ItemManager>();
                }
            }
            return instance;
        }
    }

    private List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
        SpriteRenderer sr = item.GetComponent<SpriteRenderer>();
        if (sr != null) {
            sr.enabled = false;
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public List<Item> GetAllItems()
    {
        return items;
    }
}
