using UnityEngine;
using UnityEngine.UI;

public class ShowInventoryButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _invetoryShower;
    [SerializeField] private GameObject _itemsGameObject;

    void Start () {
        Button btn = _button.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    void OnClick(){
        if (_invetoryShower.activeSelf)
        {
            _invetoryShower.gameObject.SetActive(false);
            _itemsGameObject.gameObject.SetActive(true);
        }
        else
        {
            _invetoryShower.gameObject.SetActive(true);
            _itemsGameObject.gameObject.SetActive(false);
        }
    }
}
