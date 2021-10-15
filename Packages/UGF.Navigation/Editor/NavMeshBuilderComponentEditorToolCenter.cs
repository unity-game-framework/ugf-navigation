using UGF.Navigation.Editor.EditorTools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;

namespace UGF.Navigation.Editor
{
    [EditorTool("Edit Center", typeof(NavMeshBuilderComponent))]
    internal class NavMeshBuilderComponentEditorToolCenter : ComponentBoundsCenterEditorTool
    {
        public NavMeshBuilderComponentEditorToolCenter() : base("m_center")
        {
        }
    }
}
