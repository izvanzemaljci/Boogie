using System.Collections;
using UnityEngine;

public class Song : MonoBehaviour
{
    [SerializeField]
    private SongAsset songAsset;

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

        while(timer <= songAsset.audioClip.length)
        {
            timer += Time.deltaTime;

            foreach(Beat beat in songAsset.beats)
            {
                if(beat.time == timer)
                {
                    beat.Unit.UnitLit();
                }
            }

            yield return null;
        }
    }
}
