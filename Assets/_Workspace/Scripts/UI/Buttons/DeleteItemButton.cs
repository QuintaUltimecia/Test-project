using System.Linq;
using UnityEngine;

public class DeleteItemButton : BaseButton
{
    private InventoryPanel _inventoryPanel;
    private InventorySlot _currentSlot;

    [SerializeField]
    private float _offset = 5f;

    public void Init(InventoryPanel inventoryPanel)
    {
        if (_gameObject == null)
            _gameObject = gameObject;

        _inventoryPanel = inventoryPanel;

        foreach (var item in _inventoryPanel.Slots.ToList())
        {
            item.OnClick += (value) => 
            { 
                _gameObject.SetActive(true); 
                _currentSlot = value;
                _transform.position = new Vector3(
                    _currentSlot.Transform.position.x + _offset,
                    _currentSlot.Transform.position.y - _offset,
                    _currentSlot.Transform.position.z);
            };
        }

        OnClick += () => 
        { 
            _currentSlot.Clear(); 
            _gameObject.SetActive(false); 
        };

        _gameObject.SetActive(false);
    }
}
