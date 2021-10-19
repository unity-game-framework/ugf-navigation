using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    internal static class NavMeshSourceSphereComponentGizmos
    {
        [DrawGizmo(GizmoType.Active)]
        private static void OnDrawGizmosActive(NavMeshSourceSphereComponent component, GizmoType gizmoType)
        {
            if (ToolManager.activeToolType == typeof(NavMeshSourceSphereComponentEditorToolSize))
            {
                Gizmos.color = NavMeshEditorUtility.HandlersSolidColor;
                Gizmos.matrix = component.transform.localToWorldMatrix;
                Gizmos.DrawSphere(component.Center, component.Radius * -1F);
            }
        }

        [DrawGizmo(GizmoType.InSelectionHierarchy)]
        private static void OnDrawGizmosSelection(NavMeshSourceSphereComponent component, GizmoType gizmoType)
        {
            bool enabled = component.isActiveAndEnabled
                           || ToolManager.activeToolType == typeof(NavMeshSourceSphereComponentEditorToolSize)
                           || ToolManager.activeToolType == typeof(NavMeshSourceSphereComponentEditorToolCenter);

            Gizmos.color = enabled ? NavMeshEditorUtility.HandlersEnabledColor : NavMeshEditorUtility.HandlersDisabledColor;
            Gizmos.matrix = component.transform.localToWorldMatrix;
            Gizmos.DrawWireSphere(component.Center, component.Radius);
        }
    }
}
