using UnityEditor;
using UnityEngine;

namespace UGF.Navigation.Editor.EditorTools
{
    internal static class ComponentEditorToolUtility
    {
        public static GUIContent EditCenterContent { get { return new GUIContent(EditorGUIUtility.IconContent("MoveTool").image, "Edit position of the center."); } }
        public static GUIContent EditSizeContent { get { return new GUIContent(EditorGUIUtility.IconContent("EditCollider").image, "Edit size of the shape."); } }

        public const string EDIT_CENTER_NAME = "Edit Shape Center";
        public const string EDIT_SIZE_NAME = "Edit Shape Size";
    }
}
