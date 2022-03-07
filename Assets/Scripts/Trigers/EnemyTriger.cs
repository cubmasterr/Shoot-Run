using UnityEngine;
using System.Collections.Generic;

public class EnemyTriger : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy _enemyPrefab;
    private IMovable _iMovementCondition;
    private List<Enemy> _enemys;

    private void OnEnable()
    {
        _enemys = new List<Enemy>();
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            var enemy = Instantiate(_enemyPrefab, _spawnPoints[i].position, _spawnPoints[i].rotation);
            _enemys.Add(enemy);
        }
        Enemy.OnEnemyDeath += OnEnemyDeath;
    }
    
    private void OnEnemyDeath(Enemy enemy)
    {
        if (_enemys.Exists(x => enemy == x))
        {
            _enemys.Remove(enemy);
        }
        if (_enemys.Count == 0 && _iMovementCondition != null)
        {
            Enemy.OnEnemyDeath -= OnEnemyDeath;
            _iMovementCondition.SetMovementCondition(MovementConditionEnum.Run,false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_enemys.Count > 0)
        {
       var iMovementCondition = other.GetComponent<IMovable>();
            if (iMovementCondition != null)
            {
                _iMovementCondition = iMovementCondition;
                _iMovementCondition.SetMovementCondition(MovementConditionEnum.Aim, true);
            }
        }
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDeath -= OnEnemyDeath;
    }
}