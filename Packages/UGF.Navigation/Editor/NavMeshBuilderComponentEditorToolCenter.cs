using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Navigation.Editor.EditorTools;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [EditorTool("Edit Center", typeof(NavMeshBuilderComponent))]
    internal class NavMeshBuilderComponentEditorToolCenter : ComponentEditorTool
    {
        protected override void OnToolGUI()
        {
            using (new SerializedObjectUpdateScope(SerializedObject))
            {
                SerializedProperty propertyCenter = SerializedObject.FindProperty("m_center");

                if (Tools.pivotRotation == PivotRotation.Local)
                {
                    using (new Handles.DrawingScope(Component.transform.localToWorldMatrix))
                    {
                        propertyCenter.vector3Value = Handles.PositionHandle(propertyCenter.vector3Value, Quaternion.identity);
                    }
                }
                else
                {
                    Vector3 position = Component.transform.TransformPoint(propertyCenter.vector3Value);

                    position = Handles.PositionHandle(position, Quaternion.identity);

                    propertyCenter.vector3Value = Component.transform.InverseTransformPoint(position);
                }
            }
        }
    }
}
