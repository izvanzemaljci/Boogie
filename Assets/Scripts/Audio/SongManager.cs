using UnityEngine;

public class SongManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private AudioSource audioSource;

    [Header("Instance")]
    [SerializeField]
    private Song[] songs;

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

    public Song GetSong(int id)
    {
        return songs[id];
    }

    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.Tutorial)
        {
            //TODO: Will be done when we manage song selection 
            foreach (Song song in songs)
            {
                Instantiate(song);
            }
        }
    }

    public void Play(AudioClip audioClip)
    {
        audioSource.clip = audioClip;

        UIManager.I.SetTimer(audioClip.length);

        audioSource.Play();
    }
}
