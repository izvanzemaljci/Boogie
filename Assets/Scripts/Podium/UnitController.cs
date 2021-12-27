using UnityEngine;

public class UnitController : MonoBehaviour
{
    [Header("Instance")]
    [SerializeField]
    private Unit[] units;

    [HideInInspector]
    private Unit lastHitUnit;

    public static UnitController I;

    private void Awake()
    {
        I = this;
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        GetLastHitUnit();
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
