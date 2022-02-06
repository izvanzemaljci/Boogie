using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField]
    private Button titleButton;

    [SerializeField]
    private AlphaModifier mainMenuAlpha;

    [SerializeField]
    private MainMenu mainMenu;

    [SerializeField]
    private AlphaModifier songSelectionAlpha;

    private void Start()
    {
        titleButton.onClick.AddListener(ShowMainMenu);

        mainMenu.OnPlay += ShowSongSelection;
    }

    private void OnDestroy()
    {
        mainMenu.OnPlay -= ShowSongSelection;
    }

    private void ShowMainMenu()
    {
        titleButton.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);

        mainMenuAlpha.FadeTo(1f);
    }

    private void ShowSongSelection()
    {
        mainMenu.gameObject.SetActive(false);
        songSelectionAlpha.gameObject.SetActive(true);

        songSelectionAlpha.FadeTo(1f);
    }
}
