using UGF.EditorTools.Editor.Tools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [EditorTool(NavMeshEditorUtility.EDIT_SIZE_NAME, typeof(NavMeshSourceBoxComponent))]
    internal class NavMeshSourceBoxComponentEditorToolSize : ToolComponentBoundsHandleBox
    {
        public NavMeshSourceBoxComponentEditorToolSize() : base("m_center", "m_size")
        {
            Handle.handleColor = NavMeshEditorUtility.HandlersControlColor;
            Handle.wireframeColor = Color.clear;
        }
    }
}
