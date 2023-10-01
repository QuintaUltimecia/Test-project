using UnityEngine;

public class GamePanel : BasePanel
{
    [field: SerializeField]
    public JoyStick JoyStick { get; private set; }

    [field: SerializeField]
    public WeaponAmmo WeaponAmmo { get; private set; }
}
