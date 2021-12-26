using UnityEngine;

public class UnitController : MonoBehaviour
{
    [Header("Instance")]
    [HideInInspector]
    private Unit lastHitUnit;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        GetLastHitUnit();
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
        if(!lastHitUnit)
        {
            return;
        }

        lastHitUnit.UnitLit();
    }
}
