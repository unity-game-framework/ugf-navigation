using UGF.EditorTools.Editor.Tools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;

namespace UGF.Navigation.Editor
{
    [EditorTool(NavMeshEditorUtility.EDIT_CENTER_NAME, typeof(NavMeshSourceModifierBoxComponent))]
    internal class NavMeshSourceModifierBoxComponentEditorToolCenter : ToolComponentHandlePosition
    {
        public NavMeshSourceModifierBoxComponentEditorToolCenter() : base("m_center")
        {
        }
    }
}
