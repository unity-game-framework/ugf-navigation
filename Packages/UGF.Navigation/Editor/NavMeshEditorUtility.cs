using System;
using UGF.Navigation.Runtime;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Navigation.Editor
{
    public static class NavMeshEditorUtility
    {
        public static Color HandlersEnabledColor { get; } = new Color(0.13F, 0.5F, 0.63F);
        public static Color HandlersDisabledColor { get; } = new Color(0.13F, 0.5F, 0.63F, 0.3F);
        public static Color HandlersSolidColor { get; } = new Color(0.13F, 0.5F, 0.63F, 0.5F);
        public static Color HandlersControlColor { get; } = new Color(0.19F, 0.81F, 1F);

        internal const string EDIT_CENTER_NAME = "Edit Shape Center";
        internal const string EDIT_SIZE_NAME = "Edit Shape Size";

        internal static Bounds GetTargetWorldBounds(Object target, Vector3 center, Vector3 size)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (target is not Component component) throw new ArgumentException("Target must be a component.");

            var bounds = new Bounds(center, size);

            return NavMeshUtility.GetWorldBounds(bounds, component.transform.position, component.transform.rotation, component.transform.localScale);
        }
    }
}
