using System;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;
using UnityEngine;

namespace UGF.Navigation.Editor.EditorTools
{
    internal class ComponentBoundsCenterEditorTool : ComponentEditorTool
    {
        public string CenterPropertyName { get; }
        public override GUIContent toolbarIcon { get { return ComponentEditorToolUtility.EditCenterContent; } }

        public ComponentBoundsCenterEditorTool() : this("m_center")
        {
        }

        public ComponentBoundsCenterEditorTool(string centerPropertyName)
        {
            if (string.IsNullOrEmpty(centerPropertyName)) throw new ArgumentException("Value cannot be null or empty.", nameof(centerPropertyName));

            CenterPropertyName = centerPropertyName;
        }

        protected override void OnToolRepaint()
        {
            using (new SerializedObjectUpdateScope(SerializedObject))
            {
                SerializedProperty propertyCenter = SerializedObject.FindProperty(CenterPropertyName);

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
