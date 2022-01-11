using System.Collections;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timer;

    public void Countdown(float time)
    {
        StartCoroutine(DisplayTime(time));
    }

    private IEnumerator DisplayTime(float time)
    {
        while (time > 0f)
        {
            time -= Time.deltaTime;

            timer.text = Mathf.Ceil(time).ToString();

            yield return null;
        }
    }
}
