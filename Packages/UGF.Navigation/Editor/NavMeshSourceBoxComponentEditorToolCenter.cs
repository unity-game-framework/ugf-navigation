using UGF.EditorTools.Editor.Tools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [EditorTool(NavMeshEditorUtility.EDIT_CENTER_NAME, typeof(NavMeshSourceBoxComponent))]
    internal class NavMeshSourceBoxComponentEditorToolCenter : ToolComponentHandlePosition
    {
        public NavMeshSourceBoxComponentEditorToolCenter() : base("m_center")
        {
        }

        protected override Matrix4x4 OnGetMatrix()
        {
            return Component.transform.localToWorldMatrix;
        }
    }
}
