using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Game))]
public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _darkScreen;

    private Game _game;

    private void Start()
    {
        _game = GetComponent<Game>();
        _game.Finished += OnFinished;
    }

    private void OnDisable()
    {
        _game.Finished -= OnFinished;
    }

    private void OnFinished()
    {
        _darkScreen.SetActive(true);
    }
}
