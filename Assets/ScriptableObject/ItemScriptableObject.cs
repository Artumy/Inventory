using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/Item")]
public class ItemScriptableObject : ScriptableObject
{      
    [SerializeField] private Sprite _icon;
    [SerializeField] private ItemParameter _parameter ;
    [SerializeField] private Sprite _iconParameter;
    [SerializeField] private int _numericalOfTheType;
    [SerializeField] private ItemType _itemType;

    public Sprite Icon => _icon;
    public ItemParameter ItemParameter => _parameter;
    public Sprite IconParameter => _iconParameter;
    public int NumericalOfTheType => _numericalOfTheType;

    public ItemType ItemType => _itemType;
}

public enum ItemParameter
{
    GreenHeart = 0,
    RedHeart = 1,
    Snail = 2,
    Crucifix = 3,
    Man = 4,
    IceStar = 5,
    Thunder = 6,
    GreenScull = 7,
    Fire = 8,
    WhiteWing = 9,
    Sleep = 10,
    MagicSun = 11
}

public enum ItemType{
    Armor = 0,
    Arrow = 1,
    Weapon = 2
}
