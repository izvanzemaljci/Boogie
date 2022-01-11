using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Timer timer;

    public static UIManager I;

    private void Awake()
    {
        I = this;
    }

    public void SetTimer(float time)
    {
        timer.Countdown(time);
    }
}
