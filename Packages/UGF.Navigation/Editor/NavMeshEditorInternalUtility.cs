using System;
using System.IO;
using UGF.Navigation.Runtime;
using UnityEditor;
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

        public static void DrawWireCapsule(Vector3 position, float radius, float height)
        {
            Handles.DrawWireArc(position + new Vector3(0F, height - radius, 0F), Vector3.right, -Vector3.forward, 180F, radius);
            Handles.DrawWireArc(position + new Vector3(0F, height - radius, 0F), Vector3.forward, Vector3.right, 180F, radius);
            Handles.DrawWireDisc(position + new Vector3(0F, height - radius, 0F), Vector3.up, radius);
            Handles.DrawWireArc(position - new Vector3(0F, height - radius, 0F), Vector3.right, -Vector3.forward, -180F, radius);
            Handles.DrawWireArc(position - new Vector3(0F, height - radius, 0F), Vector3.forward, Vector3.right, -180F, radius);
            Handles.DrawWireDisc(position - new Vector3(0F, height - radius, 0F), Vector3.up, radius);
            Handles.DrawLine(position + new Vector3(radius, height - radius, 0F), position + new Vector3(radius, -(height - radius), 0F));
            Handles.DrawLine(position + new Vector3(-radius, height - radius, 0F), position + new Vector3(-radius, -(height - radius), 0F));
            Handles.DrawLine(position + new Vector3(0F, height - radius, radius), position + new Vector3(0F, -(height - radius), radius));
            Handles.DrawLine(position + new Vector3(0F, height - radius, -radius), position + new Vector3(0F, -(height - radius), -radius));
        }

        public static string OpenDirectorySelectionInAssets()
        {
            string directoryData = Path.GetDirectoryName(Application.dataPath);
            string directory = EditorUtility.OpenFolderPanel("Select Directory", "Assets", string.Empty);

            directory = !string.IsNullOrEmpty(directoryData)
                ? directory.Substring(directoryData.Length + 1, directory.Length - directoryData.Length - 1)
                : directory;

            return directory;
        }
    }
}
