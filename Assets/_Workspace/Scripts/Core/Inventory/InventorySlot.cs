using UnityEngine;
using TMPro;
using System;
using UnityEngine.EventSystems;

[Serializable]
public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private bool _isEmpty = true;

    [field: SerializeField]
    public ItemUI ItemUI { get; private set; }

    [SerializeField]
    private TextMeshProUGUI _text;

    public Transform Transform { get; private set; }

    public int ItemCount { get; private set; } = -1;
    public ItemSO Item { get; private set; }

    public event Action<InventorySlot> OnClick;

    public void Init()
    {
        ItemUI.Init();
        Transform = transform;

        AddItemCount();
    }

    public bool Fill(IInventoryItem item)
    {
        if (_isEmpty == true)
        {
            ItemUI.FillFeatures(item);
            _isEmpty = false;
            Item = item.GetItem();
            AddItemCount();

            return true;
        }
        else
        {
            if (item.GetItem() == Item)
            {
                AddItemCount();
                return true;
            }

            return false;
        }
    }

    public void Clear()
    {
        if (Item != null)
        {
            if (ItemCount > 1)
                RemoveItemCount();
            else
            {
                RemoveItemCount();
                Item = null;
                ItemUI.Clear();
                _isEmpty = true;
            }
        }
    }

    private void RemoveItemCount()
    {
        UpdateText(ItemCount--);
    }

    private void AddItemCount()
    {
        UpdateText(ItemCount++);
    }

    private void UpdateText(int itemCount)
    {
        _text.text = $"{ItemCount}";

        if (ItemCount == 0)
            _text.enabled = false;
        else
        {
            _text.enabled = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke(this);
    }
}
