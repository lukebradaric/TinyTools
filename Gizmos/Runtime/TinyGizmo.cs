using UnityEngine;

[ExecuteAlways]
public class TinyGizmo : MonoBehaviour
{
    [Space]
    [Header("Gizmo")]
    [SerializeField] protected Transform gizmoTransform;
    [SerializeField] protected Color color = Color.red;

    protected virtual void Awake()
    {
        if (!gizmoTransform)
            gizmoTransform = transform;
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = color;
        DrawGizmo();
    }

    protected virtual void DrawGizmo() { }
}
