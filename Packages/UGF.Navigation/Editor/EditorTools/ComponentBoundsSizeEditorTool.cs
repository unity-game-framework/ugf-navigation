﻿using System;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace UGF.Navigation.Editor.EditorTools
{
    internal class ComponentBoundsSizeEditorTool : ComponentEditorTool
    {
        public string CenterPropertyName { get; }
        public string SizePropertyName { get; }
        public BoxBoundsHandle Handle { get; } = new BoxBoundsHandle();
        public override GUIContent toolbarIcon { get { return EditorGUIUtility.IconContent("EditCollider"); } }

        protected ComponentBoundsSizeEditorTool(string centerPropertyName, string sizePropertyName)
        {
            if (string.IsNullOrEmpty(centerPropertyName)) throw new ArgumentException("Value cannot be null or empty.", nameof(centerPropertyName));
            if (string.IsNullOrEmpty(sizePropertyName)) throw new ArgumentException("Value cannot be null or empty.", nameof(sizePropertyName));

            CenterPropertyName = centerPropertyName;
            SizePropertyName = sizePropertyName;
        }

        protected override void OnToolGUI()
        {
            using (new SerializedObjectUpdateScope(SerializedObject))
            {
                SerializedProperty propertyCenter = SerializedObject.FindProperty(CenterPropertyName);
                SerializedProperty propertySize = SerializedObject.FindProperty(SizePropertyName);

                using (new Handles.DrawingScope(Component.transform.localToWorldMatrix))
                {
                    Handle.center = propertyCenter.vector3Value;
                    Handle.size = propertySize.vector3Value;

                    Handle.DrawHandle();

                    propertyCenter.vector3Value = Handle.center;
                    propertySize.vector3Value = Handle.size;
                }
            }
        }
    }
}