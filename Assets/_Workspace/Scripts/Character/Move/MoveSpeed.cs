public class MoveSpeed
{
    public float CurrentValue { get; private set; }
    private readonly float _defaultValue = 4f;
    private readonly float _minValue = 0f;
    private readonly float _maxValue = 8f;

    public MoveSpeed()
    {
        CurrentValue = _defaultValue;
    }

    public void SetValue(float value)
    {
        if (value < _minValue)
            return;
        else if (value > _maxValue) return;

        CurrentValue = value;
    }
}
