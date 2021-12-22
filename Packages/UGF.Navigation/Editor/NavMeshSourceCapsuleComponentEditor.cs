using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [CustomEditor(typeof(NavMeshSourceCapsuleComponent), true)]
    internal class NavMeshSourceCapsuleComponentEditor : UnityEditor.Editor
    {
        private readonly GUIContent m_contentEdit = new GUIContent("Edit Shape");
        private SerializedProperty m_propertyArea;
        private SerializedProperty m_propertyCenter;
        private SerializedProperty m_propertyRadius;
        private SerializedProperty m_propertyHeight;

        private void OnEnable()
        {
            m_propertyArea = serializedObject.FindProperty("m_area");
            m_propertyCenter = serializedObject.FindProperty("m_center");
            m_propertyRadius = serializedObject.FindProperty("m_radius");
            m_propertyHeight = serializedObject.FindProperty("m_height");
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
                EditorGUILayout.PropertyField(m_propertyHeight);
            }
        }

        private bool HasFrameBounds()
        {
            return true;
        }

        private Bounds OnGetFrameBounds()
        {
            return NavMeshEditorUtility.GetTargetWorldBounds(target, m_propertyCenter.vector3Value, new Vector3(m_propertyRadius.floatValue * 2F, m_propertyHeight.floatValue, m_propertyRadius.floatValue * 2F));
        }
    }
}
