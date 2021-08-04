using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _startSpeed;

    private float _currentSpeed;

    private void Start()
    {
        _currentSpeed = _startSpeed;
    }

    public void Move(float horizontal, float vertical)
    {
        transform.Translate(_currentSpeed * horizontal * Time.deltaTime, _currentSpeed * vertical * Time.deltaTime, 0);
    }

    public void BoostSpeed(float multiplySpeedValue, float speedBoostDuration)
    {
        StartCoroutine(SpeedBoostTimer(multiplySpeedValue, speedBoostDuration));
    }

    public IEnumerator SpeedBoostTimer(float multiplySpeedValue, float speedBoostDuration)
    {
        _currentSpeed *= multiplySpeedValue;

        yield return new WaitForSeconds(speedBoostDuration);

        _currentSpeed = _startSpeed;
    }
}
