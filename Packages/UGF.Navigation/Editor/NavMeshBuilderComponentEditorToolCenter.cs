using UGF.EditorTools.Editor.Tools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [EditorTool(NavMeshEditorUtility.EDIT_CENTER_NAME, typeof(NavMeshBuilderComponent))]
    internal class NavMeshBuilderComponentEditorToolCenter : ToolComponentHandlePosition
    {
        public NavMeshBuilderComponentEditorToolCenter() : base("m_center")
        {
        }

        protected override Matrix4x4 OnGetMatrix()
        {
            return Matrix4x4.TRS(Component.transform.position, Component.transform.rotation, Component.transform.localScale);
        }
    }
}
