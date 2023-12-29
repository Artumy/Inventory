using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static List<ItemScriptableObject> _inventoryItems = new List<ItemScriptableObject>();

    public List<ItemScriptableObject> InventoryItems => _inventoryItems;

    public static void AddItem(ItemScriptableObject item)
    {
        _inventoryItems.Add(item);
    }

    public static void DeleteItem(Sprite sprite)
    {
        var item = _inventoryItems.Find(x => x.Icon == sprite);
        _inventoryItems.Remove(item);
    }
}
