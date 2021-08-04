using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private int _moveRadius;
    [SerializeField] private float _speed;
    [SerializeField] private float _collisionDistance;
    
    private Vector3 _targetPosition;

    void Start()
    {
        SetTargetPosition();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (transform.position == _targetPosition)
            SetTargetPosition();
    }

    public bool TryToCollide(Vector3 objectPosition)
    {
        if (Vector3.Distance(objectPosition, transform.position) < _collisionDistance)
            return true;
        else
            return false;
    }

    private void SetTargetPosition()
    {
        _targetPosition = Random.insideUnitCircle * _moveRadius;
    }
}
