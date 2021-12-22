using UGF.EditorTools.Editor.Tools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [EditorTool(NavMeshEditorUtility.EDIT_SIZE_NAME, typeof(NavMeshSourceSphereComponent))]
    internal class NavMeshSourceSphereComponentEditorToolSize : ToolComponentBoundsHandleSphere
    {
        public NavMeshSourceSphereComponentEditorToolSize() : base("m_center", "m_radius")
        {
            Handle.handleColor = NavMeshEditorUtility.HandlersControlColor;
            Handle.wireframeColor = Color.clear;
        }
    }
}
