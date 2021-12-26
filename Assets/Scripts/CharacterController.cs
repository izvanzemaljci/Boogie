using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Animator animator;

    [Header("Instance")]
    [SerializeField]
    private float movementSpeed;

    [HideInInspector]
    private Collider unitCollider;

    private void Update()
    {
        MoveToUnit();

        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        GetUnitCenter();
    }

    private void GetUnitCenter()
    {
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo);

        if (hit && hitInfo.transform.CompareTag("Unit"))
        {
            unitCollider = hitInfo.collider;
        }
    }

    private void MoveToUnit()
    {
        if (!unitCollider)
        {
            return;
        }

        PlayAnimation(true);
        transform.position = Vector3.MoveTowards(transform.position, unitCollider.bounds.center, movementSpeed * Time.deltaTime);
    }

    private void PlayAnimation(bool value)
    {
        if (!animator)
        {
            return;
        }

        animator.SetBool("isDancing", value);
    }
}
