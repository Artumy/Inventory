using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemPrefab : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryItemGameObject;
    [SerializeField] private GameObject _iconGameObject;
    [SerializeField] private GameObject _iconTypeGameObject;
    [SerializeField] public TextMeshProUGUI textIcon;
    [SerializeField] public TextMeshProUGUI textIconType;

    private Sprite _icon;
    private Sprite _iconParameter;
    private ItemParameter _itemParameter;
    private ItemType _itemType;
    public static event Action Deleted;

    public Sprite Icon => _icon;
    public Sprite IconParameter => _iconParameter;
    public ItemParameter ItemParameter => _itemParameter;
    public ItemType ItemType => _itemType;
    
    public void SetIcon(Sprite sprite)
    {
        _iconGameObject.GetComponent<Image>().sprite = sprite;
        _icon = _iconGameObject.GetComponent<Image>().sprite;
    }

    public void SetIconParameter(Sprite sprite)
    {
        _iconTypeGameObject.GetComponent<Image>().sprite = sprite;
        _iconParameter = _iconTypeGameObject.GetComponent<Image>().sprite;
    }

    public void SetParameter(ItemParameter parameter)
    {
        _itemParameter = parameter;
    }

    public void SetType(ItemType type)
    {
        _itemType = type;
    }

    public void DestroyItemPrefab()
    {
        Destroy(_inventoryItemGameObject);
    }

    public void DeleteItemPrefub()
    {
        Inventory.DeleteItem(_icon);
        Deleted?.Invoke();
    }

}


