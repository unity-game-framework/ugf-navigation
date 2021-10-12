using UGF.EditorTools.Editor.IMGUI.PropertyDrawers;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [CustomPropertyDrawer(typeof(NavMeshAreaMaskAttribute), true)]
    internal class NavMeshAreaMaskAttributeDrawer : PropertyDrawerTyped<NavMeshAreaMaskAttribute>
    {
        public NavMeshAreaMaskAttributeDrawer() : base(SerializedPropertyType.Integer)
        {
        }

        protected override void OnDrawProperty(Rect position, SerializedProperty serializedProperty, GUIContent label)
        {
            string[] names = GameObjectUtility.GetNavMeshAreaNames();
            string[] labels = new string[32];

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = $"Area {i}";
            }

            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                int value = GameObjectUtility.GetNavMeshAreaFromName(name);

                labels[value] = name;
            }

            serializedProperty.intValue = EditorGUI.MaskField(position, label, serializedProperty.intValue, labels);
        }
    }
}
