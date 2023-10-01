using UnityEngine;
using System.Collections.Generic;

public class ItemCreator : MonoBehaviour
{
    [SerializeField]
    private Item _itemPrefab;

    private List<ItemSO> _itemPool = new List<ItemSO>();

    public void Init()
    {
        ItemSO[] items = Resources.LoadAll<ItemSO>("SO/Items");

        for (int i = 0; i < items.Length; i++) 
            _itemPool.Add(items[i]);
    }

    public void CreateItem(Vector3 position)
    {
        Item item = Instantiate(_itemPrefab);
        int random = Random.Range(0, _itemPool.Count);
        ItemSO itemSO = _itemPool[random];
        item.Init(itemSO);
        item.transform.position = position;
    }

    public void CreateItemWithName(string name)
    {
        foreach (ItemSO itemSO in _itemPool)
        {
            if (name == itemSO.Name)
            {
                Item item = Instantiate(_itemPrefab);
                item.Init(itemSO);
            }
        }
    }
}
