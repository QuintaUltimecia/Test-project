using System.Linq;

public class EntryPoint
{
    private ResourcesLoader _resourcesLoader;

    private Player _player;
    private PlayerCamera _playerCamera;
    private PlayerCanvas _playerCanvas;

    private GridMap _gridMap;

    private ItemCreator _itemCreator;

    public EntryPoint(ResourcesLoader resourcesLoader) 
    {
        _resourcesLoader = resourcesLoader;

        LoadResources();
        Init();
        Subs();
        Start();
    }

    private void LoadResources()
    {
        ResourcesList resourcesList = new ResourcesList();

        _gridMap =_resourcesLoader.GetResource<GridMap>(resourcesList.GridMap);
        _playerCamera = _resourcesLoader.GetResource<PlayerCamera>(resourcesList.PlayerCamera);
        _playerCanvas = _resourcesLoader.GetResource<PlayerCanvas>(resourcesList.PlayerCanvas);
        _player = _resourcesLoader.GetResource<Player>(resourcesList.Player);
        _itemCreator = _resourcesLoader.GetResource<ItemCreator>(resourcesList.ItemCreator);    
    }

    private void Init()
    {
        _player.Init(
            _playerCanvas.GetInternalPanel<GamePanel>().JoyStick,
            _playerCanvas.GetInternalPanel<GamePanel>().GetInternalPanel<InventoryPanel>());

        _playerCanvas.GetInternalPanel<GamePanel>().GetInternalPanel<InventoryPanel>().Init();
        _playerCamera.Init(_player);
        _itemCreator.Init();

        _playerCanvas.GetInternalPanel<GamePanel>().GetInternalButton<AttackButton>().OnClick += () => _player.WristWeapon.Weapon.Shoot();
        _playerCanvas.GetInternalPanel<GamePanel>().WeaponAmmo.Init();
        _player.WristWeapon.Weapon.Ammo.OnChanged += () => _playerCanvas.GetInternalPanel<GamePanel>().WeaponAmmo.UpdateText(_player.WristWeapon.Weapon.Ammo.ValueClip, _player.WristWeapon.Weapon.Ammo.ValueGeneral);
    }

    private void Subs()
    {
        _player.OnDeath += () => 
        { 
            Save();
            _playerCanvas.GetInternalPanel<GameOverPanel>().Enable();
        };
    }

    private void Start()
    {
        SaveSystem saveSystem = new SaveSystem();

        InventoryData inventoryData = saveSystem.Load();

        if (inventoryData != null)
        {
            int count = _playerCanvas.GetInternalPanel<GamePanel>().GetInternalPanel<InventoryPanel>().Slots.ToList().Capacity;

            for (int i = 0; i < count; i++)
            {
                for (int c = 0; c < inventoryData.Slots[i].ItemCount; c++)
                {
                    _itemCreator.CreateItemWithName(inventoryData.Slots[i].ItemName);
                }
            }
        }

        _gridMap.EnemySpawner.SpawnEnemies();

        foreach (var item in _gridMap.EnemySpawner.EnemyList)
        {
            item.OnDeath += () => _itemCreator.CreateItem(item.transform.position);
        }

        _playerCanvas.GetInternalPanel<GamePanel>().WeaponAmmo.UpdateText(_player.WristWeapon.Weapon.Ammo.ValueClip, _player.WristWeapon.Weapon.Ammo.ValueGeneral);
    }

    private void Save()
    {
        SaveSystem saveSystem = new SaveSystem();

        saveSystem.Save(_playerCanvas.GetInternalPanel<GamePanel>().GetInternalPanel<InventoryPanel>().Slots.ToList());
    }
}
