using System;
using System.Collections;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    [Header("Instance")]
    [SerializeField]
    private Unit[] units;

    [HideInInspector]
    private Unit lastHitUnit;

    private bool enableInput = false;

    public static UnitController I;

    private void Awake()
    {
        I = this;

        GameManager.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnGameStateChanged;
    }


    void Update()
    {
        if (!enableInput)
        {
            return;
        }

        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        GetLastHitUnit();
    }

    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.PlayerTurn)
        {
            enableInput = true;

            //TODO:
            CheckUnits(SongManager.I.GetSong(0));
        }
    }

    public Unit GetUnitById(string id)
    {
        foreach (Unit unit in units)
        {
            if (unit.UnitId == id)
            {
                return unit;
            }
        }

        return null;
    }

    private void GetLastHitUnit()
    {
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo);

        if (hit && hitInfo.transform.CompareTag("Unit"))
        {
            lastHitUnit = hitInfo.transform.gameObject.GetComponent<Unit>();
            OnUnitHit();
        }
    }

    private void OnUnitHit()
    {
        if (!lastHitUnit)
        {
            return;
        }

        lastHitUnit.UnitLit();
    }

    private void CheckUnits(Song song)
    {
        SongManager.I.Play(song.SongAsset.audioClip);

        StartCoroutine(CompareUnits(song));
    }

    private IEnumerator CompareUnits(Song song)
    {
        float timer = 0f;

        while (timer <= song.SongAsset.audioClip.length)
        {
            timer += Time.deltaTime;

            foreach (Beat beat in song.SongAsset.beats)
            {
                if (Mathf.Floor(timer) == beat.time)
                {
                    if(beat.Unit == lastHitUnit)
                    {
                        Debug.Log("correct");
                    }
                    else
                    {
                        Debug.Log("wrong");
                    }
                }
            }

            yield return null;
        }
    }
}
