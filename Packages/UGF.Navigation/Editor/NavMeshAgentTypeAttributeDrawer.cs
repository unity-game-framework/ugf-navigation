using UGF.EditorTools.Editor.IMGUI.PropertyDrawers;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Editor
{
    [CustomPropertyDrawer(typeof(NavMeshAgentTypeAttribute), true)]
    internal class NavMeshAgentTypeAttributeDrawer : PropertyDrawerTyped<NavMeshAgentTypeAttribute>
    {
        public NavMeshAgentTypeAttributeDrawer() : base(SerializedPropertyType.Integer)
        {
        }

        protected override void OnDrawProperty(Rect position, SerializedProperty serializedProperty, GUIContent label)
        {
            var labels = new GUIContent[NavMesh.GetSettingsCount()];

            for (int i = 0; i < labels.Length; i++)
            {
                NavMeshBuildSettings settings = NavMesh.GetSettingsByIndex(i);
                string name = NavMesh.GetSettingsNameFromID(settings.agentTypeID);

                labels[i] = new GUIContent(name);
            }

            serializedProperty.intValue = EditorGUI.Popup(position, label, serializedProperty.intValue, labels);
        }
    }
}
