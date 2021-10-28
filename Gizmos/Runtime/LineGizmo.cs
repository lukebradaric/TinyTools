using UnityEngine;
using System.Collections.Generic;

public class LineGizmo : TinyGizmo
{
    [Space]
    [Header("Settings")]
    [SerializeField] private List<Transform> gizmoTargets;

    protected override void DrawGizmo()
    {
        if (gizmoTargets.Count == 0)
        {
            Gizmos.DrawLine(gizmoTransform.position, gizmoTransform.position + Vector3.right);
            return;
        }

        Transform startTransform = gizmoTransform;
        foreach (Transform trans in gizmoTargets)
        {
            Gizmos.DrawLine(startTransform.position, trans.position);
            startTransform = trans;
        }
    }
}
