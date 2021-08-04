using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private float _multiplySpeedValue;
    [SerializeField] private float _speedBoostDuration;

    public void BoostSpeed(PlayerMover mover)
    {
        mover.BoostSpeed(_multiplySpeedValue, _speedBoostDuration);
    }
}
