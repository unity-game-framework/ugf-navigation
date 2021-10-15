using System;
using UGF.Navigation.Runtime;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Navigation.Editor
{
    public static class NavMeshEditorUtility
    {
        public static Color GizmoColor { get; } = new Color(0.11F, 0.65F, 0.83F, 1F);
        public static Color GizmoSolidColor { get; } = new Color(0.11F, 0.65F, 0.83F, 0.25F);
        public static Color GizmoWireColor { get; } = new Color(0.11F, 0.65F, 0.83F, 1F);

        internal static Bounds InternalGetTargetWorldBounds(Object target, Vector3 center, Vector3 size)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (!(target is Component component)) throw new ArgumentException("Target must be a component.");

            var bounds = new Bounds(center, size);

            return NavMeshUtility.GetWorldBounds(bounds, component.transform.position, component.transform.rotation, component.transform.localScale);
        }
    }
}
