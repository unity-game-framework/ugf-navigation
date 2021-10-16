using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    internal static class NavMeshBuilderComponentGizmos
    {
        [DrawGizmo(GizmoType.Active)]
        private static void OnDrawGizmosActive(NavMeshBuilderComponent component, GizmoType gizmoType)
        {
            if (ToolManager.activeToolType == typeof(NavMeshBuilderComponentEditorToolSize))
            {
                Gizmos.color = NavMeshEditorUtility.HandlersSolidColor;
                Gizmos.matrix = Matrix4x4.TRS(component.transform.position, component.transform.rotation, component.transform.localScale);
                Gizmos.DrawCube(component.Center, component.Size * -1F);
            }
        }

        [DrawGizmo(GizmoType.InSelectionHierarchy)]
        private static void OnDrawGizmosSelected(NavMeshBuilderComponent component, GizmoType gizmoType)
        {
            bool enabled = component.isActiveAndEnabled
                           || ToolManager.activeToolType == typeof(NavMeshBuilderComponentEditorToolSize)
                           || ToolManager.activeToolType == typeof(NavMeshBuilderComponentEditorToolCenter);

            Gizmos.color = enabled ? NavMeshEditorUtility.HandlersEnabledColor : NavMeshEditorUtility.HandlersDisabledColor;
            Gizmos.matrix = Matrix4x4.TRS(component.transform.position, component.transform.rotation, component.transform.localScale);
            Gizmos.DrawWireCube(component.Center, component.Size);
        }
    }
}
