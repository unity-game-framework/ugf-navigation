using UGF.EditorTools.Editor.IMGUI.PropertyDrawers;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Editor
{
    [CustomPropertyDrawer(typeof(NavMeshAgentIdAttribute), true)]
    internal class NavMeshAgentIdAttributeDrawer : PropertyDrawerTyped<NavMeshAgentIdAttribute>
    {
        public NavMeshAgentIdAttributeDrawer() : base(SerializedPropertyType.Integer)
        {
        }

        protected override void OnDrawProperty(Rect position, SerializedProperty serializedProperty, GUIContent label)
        {
            var labels = new GUIContent[NavMesh.GetSettingsCount()];
            int[] values = new int[labels.Length];

            for (int i = 0; i < labels.Length; i++)
            {
                NavMeshBuildSettings settings = NavMesh.GetSettingsByIndex(i);
                string name = NavMesh.GetSettingsNameFromID(settings.agentTypeID);

                labels[i] = new GUIContent(name);
                values[i] = settings.agentTypeID;
            }

            serializedProperty.intValue = EditorGUI.IntPopup(position, label, serializedProperty.intValue, labels, values);
        }
    }
}
