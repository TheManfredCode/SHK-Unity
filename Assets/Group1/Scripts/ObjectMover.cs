using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _moveRadius;

    private Vector3 _nextPosition;

    void Start()
    {
        _nextPosition = Random.insideUnitCircle * _moveRadius;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextPosition, _speed * Time.deltaTime);

        if (transform.position == _nextPosition)
            _nextPosition = Random.insideUnitCircle * _moveRadius;
    }
}
