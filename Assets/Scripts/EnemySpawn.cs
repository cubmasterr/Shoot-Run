using UnityEngine;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;

    private void OnEnable()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
           Instantiate(_enemyPrefab, _spawnPoints[i].position, _spawnPoints[i].rotation);
        }
    }
}