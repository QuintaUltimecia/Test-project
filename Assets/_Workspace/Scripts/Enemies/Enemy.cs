using System;
using UnityEngine;

[RequireComponent(typeof(EnemyAI))]
public abstract class Enemy : MonoBehaviour, IGetDamage
{
    public Health Health { get; private set; }
    [field: SerializeField]
    public HealthBar HealthBar { get; private set; }
    public EnemyAI EnemyAI { get; private set; }
    [field: SerializeField]
    
    protected GameObject _gameObject;

    public event Action OnDeath;

    public void Init()
    {
        _gameObject = gameObject;
        EnemyAI = GetComponent<EnemyAI>();
        Health = new Health(25);

        EnemyAI.Init();
        HealthBar.Init();

        Health.OnChange += () =>
        {
            HealthBar.UpdateSlider(Health.Value, Health.MaxValue);

            if (Health.Value == 0)
                Death();
        };
    }

    public void Death()
    {
        _gameObject.SetActive(false);

        HealthBar.gameObject.SetActive(false);
        OnDeath?.Invoke();
    }
}
