using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Timer timer;

    [SerializeField]
    private AlphaModifier tutorialInstruction;

    [SerializeField]
    private AlphaModifier playInstruction;

    [SerializeField]
    private AlphaModifier songSelection;

    [SerializeField]
    private AlphaModifier replayMenu;

    public static UIManager I;

    private void Awake()
    {
        I = this;
    }

    public void SetTimer(float time)
    {
        timer.Countdown(time);
    }

    public void ShowTutorialInstruction()
    {
        tutorialInstruction.FadeTo(1f);

        StartCoroutine(HideTutorialInstruction());
    }

    private IEnumerator HideTutorialInstruction()
    {
        yield return new WaitForSeconds(1f);

        tutorialInstruction.FadeTo(0f);
    }

    public void ShowPlayInstruction()
    {
        playInstruction.FadeTo(1f);

        StartCoroutine(HidePlayInstruction());
    }

    private IEnumerator HidePlayInstruction()
    {
        yield return new WaitForSeconds(1f);

        playInstruction.FadeTo(0f);
    }

    public void ShowReplayMenu()
    {
        replayMenu.gameObject.SetActive(true);

        replayMenu.FadeTo(1f);
    }

    public void HideReplayMenu()
    {
        replayMenu.FadeTo(0f);
    }

    public void ShowSongSelection()
    {
        songSelection.gameObject.SetActive(true);

        songSelection.FadeTo(1f);
    }

    public void HideSongSelection()
    {
        songSelection.FadeTo(0f);

        songSelection.gameObject.SetActive(false);
    }
}
