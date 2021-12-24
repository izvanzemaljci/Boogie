using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private Renderer unitRenderer;

    [SerializeField]
    private Material onMaterial;

    [SerializeField]
    private Material offMaterial;

    public void UnitLit()
    {
        Invoke(nameof(SwitchMaterialOn), 0f);
        Invoke(nameof(SwitchMaterialOff), 0.5f);
    }

    private void SwitchMaterialOn()
    {
        unitRenderer.material = onMaterial;
    }

    private void SwitchMaterialOff()
    {
        unitRenderer.material = offMaterial;
    }
}
