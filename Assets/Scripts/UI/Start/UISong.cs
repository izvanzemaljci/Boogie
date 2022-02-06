using UnityEngine;
using UnityEngine.UI;

public class UISong : MonoBehaviour
{
    [SerializeField]
    private SongAsset songAsset;
    [SerializeField]
    private Button button;

    public SongAsset SongAsset { get => songAsset; }
    public Button Button { get => button; }
}
