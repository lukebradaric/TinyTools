using UnityEngine;

[ExecuteAlways]
public class WireSphereGizmo : TinyGizmo
{
    [Space]
    [Header("Settings")]
    [SerializeField] private float radius;

    protected override void DrawGizmo()
    {
        Gizmos.DrawWireSphere(gizmoTransform.position, radius);
    }
}