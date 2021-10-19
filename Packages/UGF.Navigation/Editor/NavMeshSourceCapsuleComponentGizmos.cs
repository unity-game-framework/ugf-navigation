using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    internal static class NavMeshSourceCapsuleComponentGizmos
    {
        [DrawGizmo(GizmoType.Active)]
        private static void OnDrawGizmosActive(NavMeshSourceCapsuleComponent component, GizmoType gizmoType)
        {
            if (ToolManager.activeToolType == typeof(NavMeshSourceCapsuleComponentEditorToolSize))
            {
                float offset = component.Height * 0.5F - component.Radius;

                Gizmos.color = NavMeshEditorUtility.HandlersSolidColor;
                Gizmos.matrix = component.transform.localToWorldMatrix * Matrix4x4.TRS(component.Center, Quaternion.identity, new Vector3(component.Radius, offset, component.Radius) * -1F);
                Gizmos.DrawMesh(Resources.GetBuiltinResource<Mesh>("Cylinder.fbx"));
                Gizmos.matrix = component.transform.localToWorldMatrix * Matrix4x4.TRS(component.Center + Vector3.up * offset, Quaternion.identity, Vector3.one * component.Radius * -1F);
                Gizmos.DrawMesh(Resources.GetBuiltinResource<Mesh>("Sphere.fbx"));
                Gizmos.matrix = component.transform.localToWorldMatrix * Matrix4x4.TRS(component.Center - Vector3.up * offset, Quaternion.identity, Vector3.one * component.Radius * -1F);
                Gizmos.DrawMesh(Resources.GetBuiltinResource<Mesh>("Sphere.fbx"));
            }
        }

        [DrawGizmo(GizmoType.InSelectionHierarchy)]
        private static void OnDrawGizmosSelection(NavMeshSourceCapsuleComponent component, GizmoType gizmoType)
        {
            bool enabled = component.isActiveAndEnabled
                           || ToolManager.activeToolType == typeof(NavMeshSourceCapsuleComponentEditorToolSize)
                           || ToolManager.activeToolType == typeof(NavMeshSourceCapsuleComponentEditorToolCenter);

            Gizmos.color = enabled ? NavMeshEditorUtility.HandlersEnabledColor : NavMeshEditorUtility.HandlersDisabledColor;
            Gizmos.matrix = component.transform.localToWorldMatrix;

            using (new Handles.DrawingScope(Gizmos.color, Gizmos.matrix))
            {
                NavMeshEditorInternalUtility.DrawWireCapsule(component.Center, component.Radius, component.Height * 0.5F);
            }
        }
    }
}
