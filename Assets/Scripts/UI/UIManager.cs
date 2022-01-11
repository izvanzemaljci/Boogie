using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timer;

    public static UIManager I;

    private void Awake() 
    {
        I = this;
    }

    public void SetTimer(float time)
    {
        StartCoroutine(StartTimer(time));
    }

    private IEnumerator StartTimer(float time)
    {
        while(time > 0f)
        {
            time -= Time.deltaTime;

            timer.text = Mathf.Ceil(time).ToString();

            yield return null;
        }
    }
}
