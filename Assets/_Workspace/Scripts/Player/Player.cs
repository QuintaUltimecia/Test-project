using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Player : MonoBehaviour, IItemCollected
{
    [field: SerializeField]
    public HealthBar HealthBar { get; private set; }
    [field: SerializeField]
    public WristWeapon WristWeapon { get; private set; }
    public Health Health { get; private set; }
    public Movement Movement { get; private set; }
    private InventoryPanel _inventoryPanel;

    public System.Action OnDeath;

    public bool FillFreeSlot(IInventoryItem item)
    {
        return _inventoryPanel.FillFreeSlot(item);
    }

    public void Init(IInput input, InventoryPanel inventoryPanel)
    {
        Movement = GetComponent<Movement>();
        Movement.Init(input);

        Health = new Health(100);
        HealthBar.Init();
        Health.OnChange += () => 
        { 
            HealthBar.UpdateSlider(Health.Value, Health.MaxValue);
            if (Health.Value == 0) Death();
        };
        WristWeapon.Init(transform);

        _inventoryPanel = inventoryPanel;
    }

    public void Death()
    {
        OnDeath?.Invoke();
        HealthBar.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
