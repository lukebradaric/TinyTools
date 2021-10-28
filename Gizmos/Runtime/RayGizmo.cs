using UnityEngine;

public class RayGizmo : TinyGizmo
{
    [Space]
    [Header("Settings")]
    [SerializeField] private bool normalizeDirection = false;
    [SerializeField] private Vector3 direction = new Vector3(1f, 0, 0);
    [SerializeField] private float length = 1f;

    protected override void DrawGizmo()
    {
        Vector3 dir = direction;
        if (normalizeDirection)
            dir.Normalize();

        Gizmos.DrawRay(gizmoTransform.position, dir * length);
    }
}
