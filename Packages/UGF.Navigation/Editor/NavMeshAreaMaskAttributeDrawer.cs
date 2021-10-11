﻿using UGF.EditorTools.Editor.IMGUI.PropertyDrawers;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [CustomPropertyDrawer(typeof(NavMeshAreaMaskAttribute), true)]
    internal class NavMeshAreaMaskAttributeDrawer : PropertyDrawerTyped<NavMeshAreaMaskAttribute>
    {
        public NavMeshAreaMaskAttributeDrawer() : base(SerializedPropertyType.Integer)
        {
        }

        protected override void OnDrawProperty(Rect position, SerializedProperty serializedProperty, GUIContent label)
        {
            string[] names = GameObjectUtility.GetNavMeshAreaNames();

            serializedProperty.intValue = EditorGUI.MaskField(position, label, serializedProperty.intValue, names);
        }
    }
}