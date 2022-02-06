using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI UIscore;

    private int scoring;

    public int Scoring { get => scoring; set => SetScore(value); }

    private void Start()
    {
        scoring = 0;

        GameManager.OnGameStateChanged += OnGameStateChanged;
        ReactionManager.I.OnNewHitAdded += OnNewHit;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnGameStateChanged;
        ReactionManager.I.OnNewHitAdded -= OnNewHit;
    }

    private void OnGameStateChanged(GameState state)
    {
        if(state == GameState.PlayerTurn)
        {
            SetScore(0);
        }
    }

    private void OnNewHit(bool value)
    {
        if (value)
        {
            SetScore(scoring++);
        }/* 
        else
        {
            SetScore(scoring--);

            if (scoring < 0)
            {
                SetScore(0);
            }
        } */
    }

    private void SetScore(int value)
    {
        scoring = value;
        UIscore.text = scoring.ToString();
    }
}
