using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [CustomEditor(typeof(NavMeshSourceBoxComponent), true)]
    internal class NavMeshSourceBoxComponentEditor : UnityEditor.Editor
    {
        private readonly GUIContent m_contentEdit = new GUIContent("Edit Shape");
        private SerializedProperty m_propertyArea;
        private SerializedProperty m_propertyCenter;
        private SerializedProperty m_propertySize;

        private void OnEnable()
        {
            m_propertyArea = serializedObject.FindProperty("m_area");
            m_propertyCenter = serializedObject.FindProperty("m_center");
            m_propertySize = serializedObject.FindProperty("m_size");
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
                EditorGUILayout.PropertyField(m_propertySize);
            }
        }

        private bool HasFrameBounds()
        {
            return true;
        }

        private Bounds OnGetFrameBounds()
        {
            return NavMeshEditorUtility.GetTargetWorldBounds(target, m_propertyCenter.vector3Value, m_propertySize.vector3Value);
        }
    }
}
