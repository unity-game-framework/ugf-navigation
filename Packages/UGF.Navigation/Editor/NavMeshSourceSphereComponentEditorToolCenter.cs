using UGF.EditorTools.Editor.Tools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;

namespace UGF.Navigation.Editor
{
    [EditorTool(NavMeshEditorUtility.EDIT_CENTER_NAME, typeof(NavMeshSourceSphereComponent))]
    internal class NavMeshSourceSphereComponentEditorToolCenter : ToolComponentHandlePosition
    {
        public NavMeshSourceSphereComponentEditorToolCenter() : base("m_center")
        {
        }
    }
}
