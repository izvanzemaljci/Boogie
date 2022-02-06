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

            //TODO: Will be done when we manage song selection 
            CheckUnits(SongManager.I.GetSong());
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

    private void CheckUnits(SongAsset songAsset)
    {
        SongManager.I.PlayAudioClip(songAsset.audioClip);

        StartCoroutine(CompareUnits(songAsset));
    }

    private IEnumerator CompareUnits(SongAsset songAsset)
    {
        Debug.Log("started");
        float timer = 0f;

        while (timer <= songAsset.audioClip.length)
        {
            timer += Time.deltaTime;

            foreach (Beat beat in songAsset.beats)
            {
                var floorTimer = (int)Mathf.Floor(timer);
                if (floorTimer == beat.Time)
                {
                    if(beat.Unit == lastHitUnit)
                    {
                        Debug.Log("correct " + beat.UnitID + " " + lastHitUnit.UnitId);
                        var hit = new Hit(true, lastHitUnit.UnitId, floorTimer);
                        ReactionManager.I.AddHit(hit);
                    }
                    else
                    {
                        //Debug.Log("wrong " + beat.UnitID + " " + lastHitUnit.UnitId);
                        var hit = new Hit(false, lastHitUnit.UnitId, floorTimer);
                        ReactionManager.I.AddHit(hit);
                    }
                }
            }

            yield return null;
        }
    }
}
