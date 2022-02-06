using System.Collections;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private AudioSource audioSource;

    [Header("Instance")]
    [SerializeField]
    private SongAsset songAsset;

    public static SongManager I;

    private void Awake()
    {
        I = this;

        GameManager.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnGameStateChanged;
    }

    public SongAsset GetSong()
    {
        return songAsset;
    }

    public void PlayTutorial(SongAsset songAsset)
    {
        this.songAsset = songAsset;

        StartCoroutine(ShowInstructions());
    }

    private IEnumerator ShowInstructions()
    {
        UIManager.I.ShowTutorialInstruction();

        yield return new WaitForSeconds(2f);

        PlayAudioClip(songAsset.audioClip);

        StartCoroutine(PlaySongTutorial(songAsset));
    }

    private IEnumerator PlaySongTutorial(SongAsset songAsset)
    {
        float timer = 0f;

        while (timer <= songAsset.audioClip.length)
        {
            timer += Time.deltaTime;

            foreach (Beat beat in songAsset.beats)
            {
                if (Mathf.Floor(timer) == beat.Time)
                {
                    beat.Unit.UnitLit();
                }
            }

            yield return null;
        }

        GameManager.I.SetState(GameState.PlayerTurn);
    }

    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.Tutorial)
        {

        }
    }

    public void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;

        UIManager.I.SetTimer(audioClip.length);

        audioSource.Play();
    }
}
