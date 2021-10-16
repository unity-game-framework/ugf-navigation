using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    internal static class NavMeshSourceBoxComponentGizmos
    {
        [DrawGizmo(GizmoType.Active)]
        private static void OnDrawGizmosActive(NavMeshSourceBoxComponent component, GizmoType gizmoType)
        {
            if (ToolManager.activeToolType == typeof(NavMeshSourceBoxComponentEditorToolSize))
            {
                Gizmos.color = NavMeshEditorUtility.HandlersSolidColor;
                Gizmos.matrix = component.transform.localToWorldMatrix;
                Gizmos.DrawCube(component.Center, component.Size * -1F);
            }
        }

        [DrawGizmo(GizmoType.InSelectionHierarchy)]
        private static void OnDrawGizmosSelection(NavMeshSourceBoxComponent component, GizmoType gizmoType)
        {
            bool enabled = component.isActiveAndEnabled
                           || ToolManager.activeToolType == typeof(NavMeshSourceBoxComponentEditorToolSize)
                           || ToolManager.activeToolType == typeof(NavMeshSourceBoxComponentEditorToolCenter);

            Gizmos.color = enabled ? NavMeshEditorUtility.HandlersEnabledColor : NavMeshEditorUtility.HandlersDisabledColor;
            Gizmos.matrix = component.transform.localToWorldMatrix;
            Gizmos.DrawWireCube(component.Center, component.Size);
        }
    }
}
