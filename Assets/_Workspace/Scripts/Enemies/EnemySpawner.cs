using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<Enemy> _enemyPrefabs = new List<Enemy>();

    [SerializeField]
    private List<Transform> _spawnPoint = new List<Transform>();

    private List<Enemy> _enemyList;

    public IEnumerable<Enemy> EnemyList { get { return _enemyList; } }

    public void SpawnEnemies()
    {
        _enemyList = new List<Enemy>();

        for (int i = 0; i < 3; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefabs[0]);
            enemy.Init();
            int random = Random.Range(0, _spawnPoint.Count);
            enemy.transform.position = _spawnPoint[random].position;

            _enemyList.Add(enemy);
        }
    }
}
