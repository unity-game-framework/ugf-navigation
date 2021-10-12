using UGF.EditorTools.Editor.IMGUI.PropertyDrawers;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [CustomPropertyDrawer(typeof(NavMeshAreaAttribute), true)]
    internal class NavMeshAreaAttributeDrawer : PropertyDrawerTyped<NavMeshAreaAttribute>
    {
        public NavMeshAreaAttributeDrawer() : base(SerializedPropertyType.Integer)
        {
        }

        protected override void OnDrawProperty(Rect position, SerializedProperty serializedProperty, GUIContent label)
        {
            string[] names = GameObjectUtility.GetNavMeshAreaNames();
            int[] values = new int[names.Length];
            var labels = new GUIContent[names.Length];

            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];

                values[i] = GameObjectUtility.GetNavMeshAreaFromName(name);
                labels[i] = new GUIContent(name);
            }

            serializedProperty.intValue = EditorGUI.IntPopup(position, label, serializedProperty.intValue, labels, values);
        }
    }
}
