using UGF.Navigation.Editor.EditorTools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [EditorTool(ComponentEditorToolUtility.EDIT_SIZE_NAME, typeof(NavMeshSourceModifierBoxComponent))]
    internal class NavMeshSourceModifierBoxComponentEditorToolSize : ComponentBoundsSizeEditorTool
    {
        public NavMeshSourceModifierBoxComponentEditorToolSize()
        {
            Handle.handleColor = NavMeshEditorUtility.HandlersControlColor;
            Handle.wireframeColor = Color.clear;
        }

        protected override Matrix4x4 OnGetMatrix()
        {
            return Component.transform.localToWorldMatrix;
        }
    }
}
