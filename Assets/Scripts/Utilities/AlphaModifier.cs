using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaModifier : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private float fadeTime;

    public void FadeTo(float value)
    {
        StartCoroutine(Fade(value));
    }

    private IEnumerator Fade(float value)
    {
        var startValue = canvasGroup.alpha;
        float timer = 0f;

        while(timer < fadeTime)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, value, timer);

            timer += Time.deltaTime;

            yield return null;
        }
    }
}
