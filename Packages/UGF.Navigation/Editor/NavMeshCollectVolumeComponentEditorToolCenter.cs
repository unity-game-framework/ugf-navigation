using UGF.Navigation.Editor.EditorTools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;

namespace UGF.Navigation.Editor
{
    [EditorTool(ComponentEditorToolUtility.EDIT_CENTER_NAME, typeof(NavMeshCollectVolumeComponent))]
    internal class NavMeshCollectVolumeComponentEditorToolCenter : ComponentBoundsCenterEditorTool
    {
    }
}
