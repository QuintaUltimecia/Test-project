using System;

public class Ammo
{
    public int ValueClip { get; private set; }
    public int ValueGeneral { get; private set; }

    public readonly int MaxClip;
    public const int MinValue = 0;

    public event Action OnChanged;

    public Ammo(int maxClip, int valueGeneral)
    {
        MaxClip = maxClip;
        ValueClip = maxClip;
        ValueGeneral = valueGeneral;
    }

    public bool SpendAmmo()
    {
        if (ValueClip <= MinValue)
        {
            ValueClip = MinValue;

            if (ValueGeneral != 0)
            {
                Reload();

                return true;
            }
            else 
            { 
                return false; 
            }
        }

        ValueClip--;
        OnChanged?.Invoke();
        return true;
    }

    private void Reload()
    {
        ValueGeneral -= MaxClip;
        ValueClip = MaxClip - 1;

        if (ValueGeneral < MinValue) 
        {
            ValueClip += ValueGeneral;
            ValueGeneral = 0;
        }

        OnChanged?.Invoke();
    }
}
