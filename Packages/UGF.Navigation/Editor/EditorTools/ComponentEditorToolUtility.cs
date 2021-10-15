using UnityEditor;
using UnityEngine;

namespace UGF.Navigation.Editor.EditorTools
{
    internal static class ComponentEditorToolUtility
    {
        public static GUIContent EditCenterContent { get { return new GUIContent(EditorGUIUtility.IconContent("MoveTool").image, EDIT_CENTER_TITLE); } }
        public static GUIContent EditSizeContent { get { return new GUIContent(EditorGUIUtility.IconContent("EditCollider").image, EDIT_SIZE_TITLE); } }

        public const string EDIT_CENTER_TITLE = "Edit position of the center.";
        public const string EDIT_SIZE_TITLE = "Edit size of the shape.";
    }
}
