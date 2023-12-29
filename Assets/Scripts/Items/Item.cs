using System;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject _itemGameObject;
    [SerializeField] private ItemScriptableObject _itemScriptableObject;
    private Button _button;

    private void Awake()
    {
        transform.GetComponent<Image>().sprite = _itemScriptableObject.Icon;
        _button = gameObject.GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Inventory.AddItem(_itemScriptableObject);
        Destroy(_itemGameObject);
    }
}
