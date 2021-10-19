using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [CustomEditor(typeof(NavMeshCollectVolumeComponent), true)]
    internal class NavMeshCollectVolumeComponentEditor : UnityEditor.Editor
    {
        private readonly GUIContent m_contentEdit = new GUIContent("Edit Bounds");
        private SerializedProperty m_propertyCenter;
        private SerializedProperty m_propertySize;
        private SerializedProperty m_propertyLayerMask;
        private SerializedProperty m_propertyDefaultArea;
        private SerializedProperty m_propertyCollectType;
        private ReorderableListDrawer m_listMarkups;

        private void OnEnable()
        {
            m_propertyCenter = serializedObject.FindProperty("m_center");
            m_propertySize = serializedObject.FindProperty("m_size");
            m_propertyLayerMask = serializedObject.FindProperty("m_layerMask");
            m_propertyDefaultArea = serializedObject.FindProperty("m_defaultArea");
            m_propertyCollectType = serializedObject.FindProperty("m_collectType");
            m_listMarkups = new ReorderableListDrawer(serializedObject.FindProperty("m_markups"));
            m_listMarkups.Enable();
        }

        private void OnDisable()
        {
            m_listMarkups.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                EditorGUILayout.EditorToolbarForTarget(m_contentEdit, target);
                EditorGUILayout.Space(EditorGUIUtility.standardVerticalSpacing);

                EditorGUILayout.PropertyField(m_propertyCenter);
                EditorGUILayout.PropertyField(m_propertySize);
                EditorGUILayout.PropertyField(m_propertyLayerMask);
                EditorGUILayout.PropertyField(m_propertyDefaultArea);
                EditorGUILayout.PropertyField(m_propertyCollectType);

                m_listMarkups.DrawGUILayout();
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
