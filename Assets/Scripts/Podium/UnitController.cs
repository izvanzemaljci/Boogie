using UnityEngine;

public class UnitController : MonoBehaviour
{
    private Unit lastHitUnit;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo);

            if(hit && hitInfo.transform.CompareTag("Unit"))
            {
                lastHitUnit = hitInfo.transform.gameObject.GetComponent<Unit>();
                lastHitUnit.UnitLit();
            }
        }
    }
}
