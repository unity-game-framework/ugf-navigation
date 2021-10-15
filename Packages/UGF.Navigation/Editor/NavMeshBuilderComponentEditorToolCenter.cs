using UGF.Navigation.Editor.EditorTools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;

namespace UGF.Navigation.Editor
{
    [EditorTool(ComponentEditorToolUtility.EDIT_CENTER_NAME, typeof(NavMeshBuilderComponent))]
    internal class NavMeshBuilderComponentEditorToolCenter : ComponentBoundsCenterEditorTool
    {
    }
}
