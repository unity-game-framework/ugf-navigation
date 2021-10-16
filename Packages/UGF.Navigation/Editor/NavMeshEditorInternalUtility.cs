using System;
using UGF.Navigation.Runtime;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Navigation.Editor
{
    internal static class NavMeshEditorInternalUtility
    {
        public static Bounds GetTargetWorldBounds(Object target, Vector3 center, Vector3 size)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            if (!(target is Component component)) throw new ArgumentException("Target must be a component.");

            var bounds = new Bounds(center, size);

            return NavMeshUtility.GetWorldBounds(bounds, component.transform.position, component.transform.rotation, component.transform.localScale);
        }
    }
}
