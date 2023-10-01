using UnityEngine;

public class WristWeapon : MonoBehaviour
{
    [field: SerializeField]
    public Weapon Weapon { get; private set; }

    public void Init(Transform bulletDirection)
    {
        Weapon.Init(bulletDirection);
    }
}
