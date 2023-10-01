using System;

public class Health
{
    public int Value { get; private set; }
    public const int MinValue = 0;
    public readonly int MaxValue;

    public event Action OnChange;

    public Health(int maxValue)
    {
        MaxValue = maxValue;
        Value = maxValue;
    }

    public void ApplyDamage(Damage damage)
    {
        Value -= damage.Value;

        if (Value < MinValue)
            Value = MinValue;

        OnChange?.Invoke();
    }

    public void Restore()
    {
        Value = MaxValue;

        OnChange?.Invoke();
    }
}
