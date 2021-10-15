using UGF.Navigation.Editor.EditorTools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;

namespace UGF.Navigation.Editor
{
    [EditorTool(ComponentEditorToolUtility.EDIT_SIZE_NAME, typeof(NavMeshCollectVolumeComponent))]
    internal class NavMeshCollectVolumeComponentEditorToolSize : ComponentBoundsSizeEditorTool
    {
        public NavMeshCollectVolumeComponentEditorToolSize()
        {
            Handle.SetColor(NavMeshEditorUtility.GizmoWireColor);
        }
    }
}
