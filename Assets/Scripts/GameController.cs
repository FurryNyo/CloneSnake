using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private SnakeMovement _snakeMovement;
    [SerializeField] private LevelGenerator _levelGenerator;

    public enum State
    {
        Play,
        Win,
        Lose,
    }

    public State CurrentState { get; private set; }
    
    public void OnPlayerLoss()
    {
        if (CurrentState != State.Play)
        {
            return;
        }
        CurrentState = State.Lose;
        _snakeMovement.enabled = false;
        ReloadLevel();
    }

    public void OnPlayerWin()
    {
        if (CurrentState != State.Play)
        {
            return;
        }
        CurrentState = State.Win;
        _snakeMovement.enabled = false;
        _levelGenerator.PreSeed();
        ReloadLevel();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}