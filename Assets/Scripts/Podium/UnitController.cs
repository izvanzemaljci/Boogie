using System;
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
        if(!enableInput)
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
        if(state != GameState.PlayerTurn)
        {
            return;
        }

        enableInput = true;
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
}
