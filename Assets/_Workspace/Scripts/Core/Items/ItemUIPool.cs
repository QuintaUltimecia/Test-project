using System.Collections.Generic;
using UnityEngine;

public class ItemUIPool : MonoBehaviour
{
    [SerializeField]
    private ItemUI _itemIUPrefab;

    private List<ItemUI> _itemUIPool;

    public void Init(int itemCount)
    {
        _itemUIPool = new List<ItemUI>(itemCount);

        for (int i = 0; i < _itemUIPool.Capacity; i++)
            _itemUIPool.Add(Instantiate(_itemIUPrefab, transform));
    }

    //public ItemUI GetFreeItem()
    //{
    //    foreach (ItemUI item in _itemUIPool)
    //    return _itemUIPool[0];
    //}
}
