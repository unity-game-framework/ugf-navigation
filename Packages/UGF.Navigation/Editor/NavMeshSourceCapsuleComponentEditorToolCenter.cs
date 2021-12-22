using UGF.EditorTools.Editor.Tools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;

namespace UGF.Navigation.Editor
{
    [EditorTool(NavMeshEditorUtility.EDIT_CENTER_NAME, typeof(NavMeshSourceCapsuleComponent))]
    internal class NavMeshSourceCapsuleComponentEditorToolCenter : ToolComponentHandlePosition
    {
        public NavMeshSourceCapsuleComponentEditorToolCenter() : base("m_center")
        {
        }
    }
}
