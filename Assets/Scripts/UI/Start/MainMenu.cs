using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button play;

    [SerializeField]
    private Button settings;

    [SerializeField]
    private Button exit;

    public event System.Action OnPlay;

    private void Start()
    {
        play.onClick.AddListener(Play);
        settings.onClick.AddListener(Settings);
        exit.onClick.AddListener(Exit);
    }

    private void Play()
    {
        OnPlay?.Invoke();
    }

    private void Settings()
    {
        //TODO:
    }

    private void Exit()
    {
        Application.Quit();
    }
}
