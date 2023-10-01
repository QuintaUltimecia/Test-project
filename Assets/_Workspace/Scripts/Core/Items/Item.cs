using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Item : MonoBehaviour, IInventoryItem
{
    private ItemSO _item;

    private SpriteRenderer _spriteRenderer;

    public ItemSO GetItem()
    {
        return _item;
    }

    public void Init(ItemSO item)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_item == null)
        {
            _item = item;
            _spriteRenderer.sprite = item.Sprite;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IItemCollected itemCollected))
        {
            if (itemCollected.FillFreeSlot(this))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
