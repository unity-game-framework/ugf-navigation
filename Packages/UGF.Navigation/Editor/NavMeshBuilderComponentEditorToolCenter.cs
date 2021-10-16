using UGF.Navigation.Editor.EditorTools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [EditorTool(ComponentEditorToolUtility.EDIT_CENTER_NAME, typeof(NavMeshBuilderComponent))]
    internal class NavMeshBuilderComponentEditorToolCenter : ComponentBoundsCenterEditorTool
    {
        protected override Matrix4x4 OnGetMatrix()
        {
            return Matrix4x4.TRS(Component.transform.position, Component.transform.rotation, Component.transform.localScale);
        }
    }
}
