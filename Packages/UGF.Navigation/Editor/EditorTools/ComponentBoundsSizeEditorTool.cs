using System;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace UGF.Navigation.Editor.EditorTools
{
    internal abstract class ComponentBoundsSizeEditorTool : ComponentBoundsShapeEditorTool<BoxBoundsHandle>
    {
        public string CenterPropertyName { get; }
        public string SizePropertyName { get; }
        public override GUIContent toolbarIcon { get { return ComponentEditorToolUtility.EditSizeContent; } }

        protected ComponentBoundsSizeEditorTool() : this("m_center", "m_size")
        {
        }

        protected ComponentBoundsSizeEditorTool(string centerPropertyName, string sizePropertyName) : base(new BoxBoundsHandle())
        {
            if (string.IsNullOrEmpty(centerPropertyName)) throw new ArgumentException("Value cannot be null or empty.", nameof(centerPropertyName));
            if (string.IsNullOrEmpty(sizePropertyName)) throw new ArgumentException("Value cannot be null or empty.", nameof(sizePropertyName));

            CenterPropertyName = centerPropertyName;
            SizePropertyName = sizePropertyName;
        }

        protected override void OnHandleSetup()
        {
            SerializedProperty propertyCenter = SerializedObject.FindProperty(CenterPropertyName);
            SerializedProperty propertySize = SerializedObject.FindProperty(SizePropertyName);

            Handle.center = propertyCenter.vector3Value;
            Handle.size = propertySize.vector3Value;
        }

        protected override void OnHandleChanged()
        {
            SerializedProperty propertyCenter = SerializedObject.FindProperty(CenterPropertyName);
            SerializedProperty propertySize = SerializedObject.FindProperty(SizePropertyName);

            propertyCenter.vector3Value = Handle.center;
            propertySize.vector3Value = Handle.size;
        }
    }
}
