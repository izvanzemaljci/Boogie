using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private Song[] songs;

    public static SongManager I;

    private void Awake() 
    {
        I = this;    
    }

    private void Start() {
        foreach(Song song in songs)
        {
            Instantiate(song);
        }
    }

    public void Play(AudioClip audioClip)
    {
        audioSource.clip = audioClip;

        audioSource.Play();
    }
}
