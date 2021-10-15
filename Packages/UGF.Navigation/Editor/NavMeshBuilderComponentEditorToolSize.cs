using UGF.Navigation.Editor.EditorTools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;

namespace UGF.Navigation.Editor
{
    [EditorTool("Edit Size", typeof(NavMeshBuilderComponent))]
    internal class NavMeshBuilderComponentEditorToolSize : ComponentBoundsSizeEditorTool
    {
        protected NavMeshBuilderComponentEditorToolSize() : base("m_center", "m_size")
        {
        }
    }
}
