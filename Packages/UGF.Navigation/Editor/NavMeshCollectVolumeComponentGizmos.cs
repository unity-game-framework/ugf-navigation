using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    internal static class NavMeshCollectVolumeComponentGizmos
    {
        [DrawGizmo(GizmoType.Active)]
        private static void OnDrawGizmosActive(NavMeshCollectVolumeComponent component, GizmoType gizmoType)
        {
            if (ToolManager.activeToolType == typeof(NavMeshCollectVolumeComponentEditorToolSize))
            {
                Gizmos.color = NavMeshEditorUtility.HandlersSolidColor;
                Gizmos.matrix = Matrix4x4.TRS(component.transform.position, component.transform.rotation, component.transform.localScale);
                Gizmos.DrawCube(component.Center, component.Size * -1F);
            }
        }

        [DrawGizmo(GizmoType.InSelectionHierarchy)]
        private static void OnDrawGizmosSelected(NavMeshCollectVolumeComponent component, GizmoType gizmoType)
        {
            bool enabled = component.isActiveAndEnabled
                           || ToolManager.activeToolType == typeof(NavMeshCollectVolumeComponentEditorToolSize)
                           || ToolManager.activeToolType == typeof(NavMeshCollectVolumeComponentEditorToolCenter);

            Gizmos.color = enabled ? NavMeshEditorUtility.HandlersEnabledColor : NavMeshEditorUtility.HandlersDisabledColor;
            Gizmos.matrix = Matrix4x4.TRS(component.transform.position, component.transform.rotation, component.transform.localScale);
            Gizmos.DrawWireCube(component.Center, component.Size);
        }
    }
}
