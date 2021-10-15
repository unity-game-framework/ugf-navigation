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
            Gizmos.matrix = component.transform.localToWorldMatrix;

            Gizmos.color = NavMeshEditorUtility.GizmoSolidColor;
            Gizmos.DrawCube(component.Center, component.Size);

            Gizmos.color = NavMeshEditorUtility.GizmoWireColor;
            Gizmos.DrawWireCube(component.Center, component.Size);
        }
    }
}
