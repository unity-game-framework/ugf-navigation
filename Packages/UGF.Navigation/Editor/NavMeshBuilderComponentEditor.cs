using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [CustomEditor(typeof(NavMeshBuilderComponent), true)]
    internal class NavMeshBuilderComponentEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyCenter;
        private SerializedProperty m_propertySize;
        private SerializedProperty m_propertyAgentId;
        private SerializedProperty m_propertyAuto;
        private SerializedProperty m_propertyData;
        private ReorderableListDrawer m_listCollects;

        private void OnEnable()
        {
            m_propertyCenter = serializedObject.FindProperty("m_center");
            m_propertySize = serializedObject.FindProperty("m_size");
            m_propertyAgentId = serializedObject.FindProperty("m_agentId");
            m_propertyAuto = serializedObject.FindProperty("m_auto");
            m_propertyData = serializedObject.FindProperty("m_data");
            m_listCollects = new ReorderableListDrawer(serializedObject.FindProperty("m_collects"));
            m_listCollects.Enable();
        }

        private void OnDisable()
        {
            m_listCollects.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                EditorGUILayout.EditorToolbarForTarget(new GUIContent("Edit Bounds"), target);
                EditorGUILayout.Space(EditorGUIUtility.standardVerticalSpacing);

                EditorGUILayout.PropertyField(m_propertyCenter);
                EditorGUILayout.PropertyField(m_propertySize);
                EditorGUILayout.PropertyField(m_propertyAgentId);
                EditorGUILayout.PropertyField(m_propertyAuto);
                EditorGUILayout.PropertyField(m_propertyData);

                m_listCollects.DrawGUILayout();
            }
        }
    }
}
