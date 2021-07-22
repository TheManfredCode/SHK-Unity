using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;
    private static int s_positiveDirection = 1;
    private static int s_negativeDirection = -1;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            _mover.MoveHorizontal(s_positiveDirection);

        if (Input.GetKey(KeyCode.S))
            _mover.MoveHorizontal(s_negativeDirection);

        if (Input.GetKey(KeyCode.D))
            _mover.MoveVertical(s_positiveDirection);

        if (Input.GetKey(KeyCode.A))
            _mover.MoveVertical(s_negativeDirection);
    }
}
