using System;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEditor.EditorTools;

namespace UGF.Navigation.Editor
{
    internal static class NavMeshBuilderComponentGizmos
    {
        [DrawGizmo(GizmoType.Active)]
        private static void OnDrawGizmosActive(NavMeshBuilderComponent component, GizmoType gizmoType)
        {
            if (component == null) throw new ArgumentNullException(nameof(component));

            if (ToolManager.activeToolType == typeof(NavMeshBuilderComponentEditorToolSize))
            {
                NavMeshEditorInternalUtility.DrawGizmoBoundsBox(component.transform, component.Center, component.Size);
            }
        }

        [DrawGizmo(GizmoType.InSelectionHierarchy)]
        private static void OnDrawGizmosSelected(NavMeshBuilderComponent component, GizmoType gizmoType)
        {
            if (component == null) throw new ArgumentNullException(nameof(component));

            bool enabled = component.isActiveAndEnabled
                           || ToolManager.activeToolType == typeof(NavMeshBuilderComponentEditorToolSize)
                           || ToolManager.activeToolType == typeof(NavMeshBuilderComponentEditorToolCenter);

            NavMeshEditorInternalUtility.DrawGizmoBoundsWire(component.transform, component.Center, component.Size, enabled);
        }
    }
}
