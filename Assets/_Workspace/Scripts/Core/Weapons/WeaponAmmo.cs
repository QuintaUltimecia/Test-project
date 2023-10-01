using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class WeaponAmmo : MonoBehaviour
{
    private TextMeshProUGUI _text;

    public void Init()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(int value, int valueGeneral)
    {
        _text.text = $"{value}/{valueGeneral}";
    }
}
