using System;
using System.Collections.Generic;

[Serializable]
public class InventoryData
{
    public List<SlotData> Slots;

    public InventoryData(List<InventorySlot> slots)
    {
        Slots = new List<SlotData>();

        for (int i = 0; i < slots.Count; i++)
        {
            string itemName;

            if (slots[i].Item != null)
            {
                itemName = slots[i].Item.Name;
            }
            else
            {
                itemName = null;
            }

            Slots.Add(new SlotData(i, itemName, slots[i].ItemCount));
        }
    }
}