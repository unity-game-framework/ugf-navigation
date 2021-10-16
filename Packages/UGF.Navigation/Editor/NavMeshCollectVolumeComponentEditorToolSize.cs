using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Navigation.Editor.EditorTools;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [EditorTool(ComponentEditorToolUtility.EDIT_SIZE_NAME, typeof(NavMeshCollectVolumeComponent))]
    internal class NavMeshCollectVolumeComponentEditorToolSize : ComponentBoundsSizeEditorTool
    {
        public NavMeshCollectVolumeComponentEditorToolSize()
        {
            Handle.handleColor = NavMeshEditorUtility.HandlersControlColor;
            Handle.wireframeColor = Color.clear;
        }

        protected override Matrix4x4 OnGetMatrix()
        {
            return Matrix4x4.TRS(Component.transform.position, Component.transform.rotation, Component.transform.localScale);
        }

        protected override void OnToolGUI()
        {
            using (new SerializedObjectUpdateScope(SerializedObject))
            {
                SerializedProperty propertyCenter = SerializedObject.FindProperty(CenterPropertyName);
                SerializedProperty propertySize = SerializedObject.FindProperty(SizePropertyName);
                Matrix4x4 matrix = OnGetMatrix();
                Vector3 scale = Component.transform.localScale;

                using (new Handles.DrawingScope(matrix))
                {
                    Handle.center = propertyCenter.vector3Value;
                    Handle.size = Vector3.Scale(propertySize.vector3Value, scale);

                    Handle.DrawHandle();

                    propertyCenter.vector3Value = Handle.center;
                    propertySize.vector3Value = new Vector3(Handle.size.x / scale.x, Handle.size.y / scale.y, Handle.size.z / scale.z);
                }
            }
        }
    }
}
