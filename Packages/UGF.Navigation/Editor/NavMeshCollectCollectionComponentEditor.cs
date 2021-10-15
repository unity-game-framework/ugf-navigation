using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Navigation.Runtime;
using UnityEditor;

namespace UGF.Navigation.Editor
{
    [CustomEditor(typeof(NavMeshCollectCollectionComponent), true)]
    internal class NavMeshCollectCollectionComponentEditor : UnityEditor.Editor
    {
        private ReorderableListDrawer m_listSources;

        private void OnEnable()
        {
            m_listSources = new ReorderableListDrawer(serializedObject.FindProperty("m_sources"));
            m_listSources.Enable();
        }

        private void OnDisable()
        {
            m_listSources.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                m_listSources.DrawGUILayout();
            }
        }
    }
}
