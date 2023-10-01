using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class SaveSystem
{
    private string _fileName = "Inventory.json";
    private string _editorDirectory = "_Workspace/Saves";
    private string _path;

    private InventoryData _inventoryData;

    public SaveSystem()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _path = $"{Application.persistentDataPath}{Path.AltDirectorySeparatorChar}";
#else
        _path = $"{Application.dataPath}/{_editorDirectory}/{_fileName}";
#endif
    }

    public void Save(List<InventorySlot> slot)
    {
        _inventoryData = new InventoryData(slot);

        string json = JsonUtility.ToJson(_inventoryData);

        using (var writer = new StreamWriter(_path))
            writer.WriteLine(json);
    }

    public InventoryData Load()
    {
        string json = "";

        if (!File.Exists(_path))
            return null;

        using (var reader = new StreamReader(_path))
            json += reader.ReadLine();

        return JsonUtility.FromJson<InventoryData>(json);
    }
}
