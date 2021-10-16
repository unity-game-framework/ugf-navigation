using System;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;
using UnityEngine;

namespace UGF.Navigation.Editor.EditorTools
{
    internal abstract class ComponentBoundsCenterEditorTool : ComponentEditorTool
    {
        public string CenterPropertyName { get; }
        public override GUIContent toolbarIcon { get { return ComponentEditorToolUtility.EditCenterContent; } }

        protected ComponentBoundsCenterEditorTool() : this("m_center")
        {
        }

        protected ComponentBoundsCenterEditorTool(string centerPropertyName)
        {
            if (string.IsNullOrEmpty(centerPropertyName)) throw new ArgumentException("Value cannot be null or empty.", nameof(centerPropertyName));

            CenterPropertyName = centerPropertyName;
        }

        protected abstract Matrix4x4 OnGetMatrix();

        protected override void OnToolGUI()
        {
            using (new SerializedObjectUpdateScope(SerializedObject))
            {
                SerializedProperty propertyCenter = SerializedObject.FindProperty(CenterPropertyName);
                Matrix4x4 matrix = OnGetMatrix();
                Vector3 position = matrix.MultiplyPoint3x4(propertyCenter.vector3Value);
                Quaternion rotation = Tools.pivotRotation == PivotRotation.Local ? Component.transform.rotation : Quaternion.identity;

                position = Handles.PositionHandle(position, rotation);

                propertyCenter.vector3Value = matrix.inverse.MultiplyPoint3x4(position);
            }
        }
    }
}
