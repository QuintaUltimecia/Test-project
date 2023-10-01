using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Transform _bulletPoint;

    [SerializeField]
    private Bullet _bullet;

    public Ammo Ammo;

    private PoolObjects<Bullet> _bulletPool;

    public void Init(Transform bulletDurection)
    {
        _bulletPool = new PoolObjects<Bullet>(_bullet, 30, _bulletPoint);

        foreach (Bullet bullet in _bulletPool.Pool) 
            bullet.Init(_bulletPoint, bulletDurection);

        Ammo = new Ammo(30, 110);
    }

    public void Shoot()
    {
        if (Ammo.SpendAmmo())
        {
            Bullet bullet = _bulletPool.GetFreeElement();
            bullet.transform.SetParent(null);
        }
    }
}
