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
        private SerializedProperty m_propertyBuildOnStart;
        private SerializedProperty m_propertyCenter;
        private SerializedProperty m_propertySize;
        private SerializedProperty m_propertyAgentId;
        private SerializedProperty m_propertyData;
        private ReorderableListDrawer m_listCollects;

        private void OnEnable()
        {
            m_propertyBuildOnStart = serializedObject.FindProperty("m_buildOnStart");
            m_propertyCenter = serializedObject.FindProperty("m_center");
            m_propertySize = serializedObject.FindProperty("m_size");
            m_propertyAgentId = serializedObject.FindProperty("m_agentId");
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

                EditorGUILayout.PropertyField(m_propertyBuildOnStart);

                EditorGUILayout.EditorToolbarForTarget(new GUIContent("Edit Bounds"), target);
                EditorGUILayout.Space(EditorGUIUtility.standardVerticalSpacing);

                EditorGUILayout.PropertyField(m_propertyCenter);
                EditorGUILayout.PropertyField(m_propertySize);
                EditorGUILayout.PropertyField(m_propertyAgentId);
                EditorGUILayout.PropertyField(m_propertyData);

                m_listCollects.DrawGUILayout();
            }
        }

        private bool HasFrameBounds()
        {
            return true;
        }

        private Bounds OnGetFrameBounds()
        {
            return NavMeshEditorInternalUtility.GetTargetWorldBounds(target, m_propertyCenter.vector3Value, m_propertySize.vector3Value);
        }
    }
}
