using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    private Image _image;

    public void Init()
    {
        _image = GetComponent<Image>();
        _image.color = new Color(1, 1, 1, 0);
    }

    public void FillFeatures(IInventoryItem inventoryItem)
    {
        _image.sprite = inventoryItem.GetItem().Sprite;
        _image.preserveAspect = true;
        _image.color = Color.white;
    }

    public void Clear()
    {
        _image.sprite = null;
        _image.color = new Color(1, 1, 1, 0);
    }
}
