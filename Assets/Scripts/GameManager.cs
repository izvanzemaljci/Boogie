using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Should probably a session manager 
public enum GameState
{
    Tutorial,
    PlayerTurn,
    Scoring
}

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        I = this;
    }

    private void Start()
    {
        SetState(GameState.Tutorial);
    }


    public void SetState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Tutorial:
                HandleTutorial();
                break;
            case GameState.PlayerTurn:
                HandlePlayerTurn();
                break;
            case GameState.Scoring:
                HandleScoring();
                break;
            default:
                Debug.Log("No game state provided.");
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }


    private void HandleTutorial()
    {
    }

    private void HandleScoring()
    {
    }

    private void HandlePlayerTurn()
    {
    }
}