using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private float _collisionDistance;
    [SerializeField] private PlayerMover _player;
    [SerializeField] private GameObject _darkScreen;

    private ObjectMover[] _objectMovers;
    private Enemy[] _enemies;
    private int _enemyCount;

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

            if (Vector3.Distance(_player.transform.position, objectMover.transform.position) < _collisionDistance)
            {
                if (objectMover.TryGetComponent(out Enemy enemy))
                {
                    Destroy(objectMover.gameObject);
                    _enemyCount--;
                    CheckEnemies();
                }

                if (objectMover.TryGetComponent(out SpeedBooster speedBooster))
                {
                    _player.BoostSpeed();
                    Destroy(objectMover.gameObject);
                }
            }
        }
    }

    private void CheckEnemies()
    {
        if (_enemyCount <= 0)
            End();
    }

    private void End()
    {
        _darkScreen.SetActive(true);
    }
}
