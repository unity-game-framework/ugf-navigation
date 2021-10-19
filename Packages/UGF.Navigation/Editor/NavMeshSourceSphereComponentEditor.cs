using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [CustomEditor(typeof(NavMeshSourceSphereComponent), true)]
    internal class NavMeshSourceSphereComponentEditor : UnityEditor.Editor
    {
        private readonly GUIContent m_contentEdit = new GUIContent("Edit Shape");
        private SerializedProperty m_propertyArea;
        private SerializedProperty m_propertyCenter;
        private SerializedProperty m_propertyRadius;

        private void OnEnable()
        {
            m_propertyArea = serializedObject.FindProperty("m_area");
            m_propertyCenter = serializedObject.FindProperty("m_center");
            m_propertyRadius = serializedObject.FindProperty("m_radius");
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                EditorGUILayout.PropertyField(m_propertyArea);

                EditorGUILayout.EditorToolbarForTarget(m_contentEdit, target);
                EditorGUILayout.Space(EditorGUIUtility.standardVerticalSpacing);

                EditorGUILayout.PropertyField(m_propertyCenter);
                EditorGUILayout.PropertyField(m_propertyRadius);
            }
        }
    }
}
