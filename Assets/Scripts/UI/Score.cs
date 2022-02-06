using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI UIscore;

    private int scoring;

    public int Scoring { get => scoring; set => SetScore(value); }

    private void Start()
    {
        scoring = 0;

        ReactionManager.I.OnNewHitAdded += OnNewHit;
    }

    private void OnDestroy()
    {
        ReactionManager.I.OnNewHitAdded -= OnNewHit;
    }

    private void OnNewHit(bool value)
    {
        if (value)
        {
            Scoring++;
        }
        else
        {
            Scoring--;

            if (scoring < 0)
            {
                scoring = 0;
            }
        }
    }

    private void SetScore(int value)
    {
        scoring = value;
        UIscore.text = scoring.ToString();
    }
}
