using System.Collections;
using UnityEngine;

public class Song : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;

    [SerializeField]
    private Beat[] beats;

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
        SongManager.I.Play(audioClip);

        StartCoroutine(PlaySong());
    }

    private IEnumerator PlaySong()
    {
        float timer = 0f;

        while(timer <= audioClip.length)
        {
            timer += Time.deltaTime;

            foreach(Beat beat in beats)
            {
                if(beat.time == timer)
                {
                    beat.unit.UnitLit();
                }
            }

            yield return null;
        }
    }
}
