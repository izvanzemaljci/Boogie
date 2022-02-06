using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReplayMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI finalScore;

    [SerializeField]
    private Button replayButton;

    [SerializeField]
    private Button songSelection;

    [SerializeField]
    private Score score;

    private void OnEnable()
    {
        finalScore.text = score.Scoring.ToString();

        UIManager.I.ShowReplayMenu();

        replayButton.onClick.AddListener(Replay);

        songSelection.onClick.AddListener(ShowSongSelection);
    }

    private void Replay()
    {
        GameManager.I.SetState(GameState.Tutorial);

        SongManager.I.PlayTutorial(SongManager.I.GetSong());

        UIManager.I.HideReplayMenu();

        gameObject.SetActive(false);
    }

    private void ShowSongSelection()
    {
        UIManager.I.HideReplayMenu();

        UIManager.I.ShowSongSelection();

        gameObject.SetActive(false);
    }
}
