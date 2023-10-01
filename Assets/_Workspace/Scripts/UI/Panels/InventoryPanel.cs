using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryPanel : BasePanel
{
    [SerializeField]
    private List<InventorySlot> _slots = new List<InventorySlot>();

    public IEnumerable<InventorySlot> Slots { get => _slots; }

    public void Init()
    {
        foreach (InventorySlot slot in _slots) 
            slot.Init();

        GetInternalButton<DeleteItemButton>().Init(this);
    }

    public bool FillFreeSlot(IInventoryItem item)
    {
        foreach (InventorySlot slot in _slots)
            if (slot.Fill(item))
            {
                return true;
            }

        return false;
    }
}