using UGF.EditorTools.Editor.Tools;
using UGF.Navigation.Runtime;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [EditorTool(NavMeshEditorUtility.EDIT_SIZE_NAME, typeof(NavMeshSourceCapsuleComponent))]
    internal class NavMeshSourceCapsuleComponentEditorToolSize : ToolComponentBoundsHandleCapsule
    {
        public NavMeshSourceCapsuleComponentEditorToolSize() : base("m_center", "m_height", "m_radius")
        {
            Handle.handleColor = NavMeshEditorUtility.HandlersControlColor;
            Handle.wireframeColor = Color.clear;
        }
    }
}
