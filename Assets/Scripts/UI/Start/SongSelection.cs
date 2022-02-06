using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject startScreen;

    [SerializeField]
    private UISong[] UISongs;

    private void Start()
    {
        foreach (UISong UISong in UISongs)
        {
            UISong.Button.onClick.AddListener(() => StartSession(UISong.SongAsset));
        }
    }

    private void StartSession(SongAsset songAsset)
    {
        GameManager.I.SetState(GameState.Tutorial);

        SongManager.I.PlayTutorial(songAsset);

        startScreen.SetActive(false);
    }



    //set song
}
