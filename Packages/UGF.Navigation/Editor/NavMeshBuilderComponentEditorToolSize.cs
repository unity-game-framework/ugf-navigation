using UGF.EditorTools.Editor.Tools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [EditorTool(NavMeshEditorUtility.EDIT_SIZE_NAME, typeof(NavMeshBuilderComponent))]
    internal class NavMeshBuilderComponentEditorToolSize : ToolComponentBoundsHandleBox
    {
        public NavMeshBuilderComponentEditorToolSize() : base("m_center", "m_size")
        {
            Handle.handleColor = NavMeshEditorUtility.HandlersControlColor;
            Handle.wireframeColor = Color.clear;
        }

        protected override Matrix4x4 OnGetMatrix()
        {
            return Matrix4x4.TRS(Component.transform.position, Component.transform.rotation, Component.transform.localScale);
        }
    }
}
