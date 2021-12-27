using UnityEngine;

[CreateAssetMenu(menuName = "Boogie/SongAsset")]
public class SongAsset : ScriptableObject
{
    public AudioClip audioClip;
    public Beat[] beats;
}
