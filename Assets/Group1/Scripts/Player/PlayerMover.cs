using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _multiplySpeedValue;
    [SerializeField] private float _speedBoostDuration;

    private WaitForSeconds _waitSpeedBoostDuration;
    private float _currentSpeed;

    private void Start()
    {
        _waitSpeedBoostDuration = new WaitForSeconds(_speedBoostDuration);
        _currentSpeed = _startSpeed;
    }

    public void MoveHorizontal(int direction)
    {
        transform.Translate(0, _currentSpeed * direction * Time.deltaTime, 0);
    }

    public void MoveVertical(int direction)
    {
        transform.Translate(_currentSpeed * direction * Time.deltaTime, 0, 0);
    }

    public void BoostSpeed()
    {
        _currentSpeed *= _multiplySpeedValue;

        StartCoroutine(SpeedBoostTimer());
    }

    private IEnumerator SpeedBoostTimer()
    {
        yield return _waitSpeedBoostDuration;

        _currentSpeed = _startSpeed;
    }
}
