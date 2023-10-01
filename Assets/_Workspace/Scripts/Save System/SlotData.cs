using System;

[Serializable]
public class SlotData
{
    public int SlotID;
    public string ItemName;
    public int ItemCount;

    public SlotData(int slotID, string itemName, int itemCount)
    {
        SlotID = slotID;
        ItemName = itemName;
        ItemCount = itemCount;
    }
}
