using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [field: SerializeField]
    public Image Slider { get; private set; }

    private Transform _transform;
    private Camera _camera;

    private Transform _healthBarPoint;

    public void Init()
    {
        _transform = transform;
        _healthBarPoint = _transform.parent;
        _camera = Camera.main;

        _transform.SetParent(HealthBarContainer.Transform);
    }

    public void UpdateSlider(float value, float maxValue)
    {
        Slider.fillAmount = value / maxValue;
    }

    public void Update()
    {
        if (_healthBarPoint != null)
            _transform.position = _camera.WorldToScreenPoint(_healthBarPoint.position);
    }
}
