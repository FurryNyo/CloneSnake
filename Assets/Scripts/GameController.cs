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
    public GameObject WinPanel;
    public GameObject DeathPanel;

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
        DeathPanel.SetActive(true);
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
        WinPanel.SetActive(true);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Start()
    {
        WinPanel.SetActive(false);
        DeathPanel.SetActive(false);
    }
}