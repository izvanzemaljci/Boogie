using System.Collections;
using UnityEngine;

//TODO: should maybe be moved to song manager idk we'll see
public class Song : MonoBehaviour
{
    [SerializeField]
    private SongAsset songAsset;

    public SongAsset SongAsset => songAsset;

    private void OnEnable()
    {
        //sort playing times

        //play
        Play();
    }

    private void SortPlayingTimes()
    {

    }

    public void Play()
    {
        SongManager.I.Play(songAsset.audioClip);

        StartCoroutine(PlaySong());
    }

    private IEnumerator PlaySong()
    {
        float timer = 0f;

        while (timer <= songAsset.audioClip.length)
        {
            timer += Time.deltaTime;

            foreach (Beat beat in songAsset.beats)
            {
                if (Mathf.Floor(timer) == beat.time)
                {
                    beat.Unit.UnitLit();
                }
            }

            yield return null;
        }

        GameManager.I.SetState(GameState.PlayerTurn);
    }
}
