public class Damage
{
    public int Value { get; private set; }
    public const int MinValue = 0;
    public readonly int MaxValue;

    public Damage(int maxValue)
    {
        if (maxValue < MinValue)
            throw new System.Exception("Damage can't be < 0");

        MaxValue = maxValue;
        Value = maxValue;
    }
}
