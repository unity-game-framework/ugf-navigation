using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Navigation.Editor.EditorTools;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [EditorTool("Edit Size", typeof(NavMeshBuilderComponent))]
    internal class NavMeshBuilderComponentEditorToolSize : ComponentEditorTool
    {
        private readonly BoxBoundsHandle m_handle = new BoxBoundsHandle();

        protected override void OnToolGUI()
        {
            using (new SerializedObjectUpdateScope(SerializedObject))
            {
                SerializedProperty propertyCenter = SerializedObject.FindProperty("m_center");
                SerializedProperty propertySize = SerializedObject.FindProperty("m_size");

                using (new Handles.DrawingScope(Color.white, Component.transform.localToWorldMatrix))
                {
                    m_handle.center = propertyCenter.vector3Value;
                    m_handle.size = propertySize.vector3Value;

                    m_handle.DrawHandle();

                    propertyCenter.vector3Value = m_handle.center;
                    propertySize.vector3Value = m_handle.size;
                }
            }
        }
    }
}
