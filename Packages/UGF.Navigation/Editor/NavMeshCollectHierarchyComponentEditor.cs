using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Navigation.Runtime;
using UnityEditor;

namespace UGF.Navigation.Editor
{
    [CustomEditor(typeof(NavMeshCollectHierarchyComponent), true)]
    internal class NavMeshCollectHierarchyComponentEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyRoot;
        private SerializedProperty m_propertyLayerMask;
        private SerializedProperty m_propertyDefaultArea;
        private SerializedProperty m_propertyCollectType;
        private ReorderableListDrawer m_listMarkups;

        private void OnEnable()
        {
            m_propertyRoot = serializedObject.FindProperty("m_root");
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

                EditorGUILayout.PropertyField(m_propertyRoot);
                EditorGUILayout.PropertyField(m_propertyLayerMask);
                EditorGUILayout.PropertyField(m_propertyDefaultArea);
                EditorGUILayout.PropertyField(m_propertyCollectType);

                m_listMarkups.DrawGUILayout();
            }
        }
    }
}
