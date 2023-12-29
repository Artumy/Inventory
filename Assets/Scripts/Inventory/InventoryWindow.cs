using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryItemPrefab;
    [SerializeField] private Inventory _inventory;

    private List<InventoryItemPrefab> _needToShowItems = new List<InventoryItemPrefab>();

    private void OnEnable()
    {
        ShowAllItem();
        InventoryItemPrefab.Deleted += Redraw;
    }

    private void OnDisable()
    {
        InventoryItemPrefab.Deleted -= Redraw;
    }

    private void Redraw()
    {
        var needDestroyItems = gameObject.GetComponentsInChildren<InventoryItemPrefab>();
        foreach (var item in needDestroyItems)
        {
            item.DestroyItemPrefab();
        }
        _needToShowItems.Clear();
        
        var list = _inventory.InventoryItems.GroupBy(x => x.Icon).Select(x => x.First()).ToList();

        for (int i = 0; i < list.Count; i++)
        {
            var item = Instantiate(_inventoryItemPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            
            var itemPrefab = item.GetComponent<InventoryItemPrefab>();

            item.transform.SetParent(transform);

            int countOfitems = 0;
            for (int j = 0; j < _inventory.InventoryItems.Count; j++)
            {
                if (list[i].Icon.GetHashCode() == _inventory.InventoryItems[j].Icon.GetHashCode())
                    countOfitems++;
            }
            
            itemPrefab.SetIcon(list[i].Icon);
            itemPrefab.SetIconParameter(list[i].IconParameter);
            itemPrefab.textIcon.text += countOfitems;
            itemPrefab.textIconType.text += list[i].NumericalOfTheType;
            itemPrefab.SetParameter(list[i].ItemParameter);
            itemPrefab.SetType(list[i].ItemType);

            SetDefaultSettings(itemPrefab);
            
            _needToShowItems.Add(itemPrefab);
        }
    }

    private void SetDefaultSettings(InventoryItemPrefab item)
    {
        item.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
    }

    public void FilterByParameter(int numberOfTheParameter)
    {
        ShowAllItem();
        
        ItemParameter parameter = (ItemParameter)numberOfTheParameter;
        
        for (int i = 0; i < _needToShowItems.Count; i++)
        {
            if (_needToShowItems[i].ItemParameter != parameter)
                _needToShowItems[i].DestroyItemPrefab();
        }
    }

    public void ShowAllItem()
    {
        Redraw();
    }

    public void FilterByType(int numberOfTheType)
    {
        ShowAllItem();

        ItemType type = (ItemType)numberOfTheType;
        
        for (int i = 0; i < _needToShowItems.Count; i++)
        {
            if (_needToShowItems[i].ItemType != type)
                _needToShowItems[i].DestroyItemPrefab();
        }
    }
}
