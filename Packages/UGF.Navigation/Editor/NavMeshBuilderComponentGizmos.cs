using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    internal static class NavMeshBuilderComponentGizmos
    {
        [DrawGizmo(GizmoType.Selected | GizmoType.InSelectionHierarchy | GizmoType.Active)]
        private static void OnDrawGizmos(NavMeshBuilderComponent component, GizmoType gizmoType)
        {
            Gizmos.color = Color.white;
            Gizmos.matrix = component.transform.localToWorldMatrix;
            Gizmos.DrawWireCube(component.Center, component.Size);
        }
    }
}
