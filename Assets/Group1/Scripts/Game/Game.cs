using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    [SerializeField] private PlayerMover _player;

    private ObjectMover[] _objectMovers;
    private Enemy[] _enemies;
    private int _enemyCount;

    public event UnityAction Finished;

    private void Start()
    {
        _objectMovers = FindObjectsOfType<ObjectMover>();
        _enemies = FindObjectsOfType<Enemy>();
        _enemyCount = _enemies.Length;
    }

    private void Update()
    {
        foreach (ObjectMover objectMover in _objectMovers)
        {
            if (objectMover == null)
                continue;

            if (objectMover.TryToCollide(_player.transform.position))
            {
                if (objectMover.TryGetComponent(out Enemy enemy))
                {
                    Destroy(objectMover.gameObject);
                    _enemyCount--;
                    CheckEnemies();
                }

                if (objectMover.TryGetComponent(out SpeedBooster speedBooster))
                {
                    speedBooster.BoostSpeed(_player);
                    Destroy(speedBooster.gameObject);
                }
            }
        }
    }

    private void CheckEnemies()
    {
        if (_enemyCount <= 0)
            Finished?.Invoke();
    }

}
