using UGF.Navigation.Editor.EditorTools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [EditorTool(ComponentEditorToolUtility.EDIT_CENTER_NAME, typeof(NavMeshSourceBoxComponent))]
    internal class NavMeshSourceBoxComponentEditorToolCenter : ComponentBoundsCenterEditorTool
    {
        protected override Matrix4x4 OnGetMatrix()
        {
            return Component.transform.localToWorldMatrix;
        }
    }
}
