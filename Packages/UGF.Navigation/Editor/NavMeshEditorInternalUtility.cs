using System;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Navigation.Editor
{
    internal static class NavMeshEditorInternalUtility
    {
        public static void DrawGizmoBoundsBox(Transform transform, Vector3 center, Vector3 size)
        {
            Gizmos.color = NavMeshEditorUtility.HandlersSolidColor;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
            Gizmos.DrawCube(center, size * -1F);
        }

        public static void DrawGizmoBoundsWire(Transform transform, Vector3 center, Vector3 size, bool enabled)
        {
            Gizmos.color = enabled ? NavMeshEditorUtility.HandlersEnabledColor : NavMeshEditorUtility.HandlersDisabledColor;
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
            Gizmos.DrawWireCube(center, size);
        }

        public static Bounds GetTargetWorldBounds(Object target, Vector3 center, Vector3 size)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (!(target is Component component)) throw new ArgumentException("Target must be a component.");

            var bounds = new Bounds(center, size);

            return NavMeshUtility.GetWorldBounds(bounds, component.transform.position, component.transform.rotation, component.transform.localScale);
        }
    }
}
