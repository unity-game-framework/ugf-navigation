using UGF.Navigation.Editor.EditorTools;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace UGF.Navigation.Editor
{
    [EditorTool(ComponentEditorToolUtility.EDIT_SIZE_NAME, typeof(NavMeshSourceSphereComponent))]
    internal class NavMeshSourceSphereComponentEditorToolSize : ComponentBoundsShapeEditorTool<SphereBoundsHandle>
    {
        public NavMeshSourceSphereComponentEditorToolSize() : base(new SphereBoundsHandle())
        {
            Handle.handleColor = NavMeshEditorUtility.HandlersControlColor;
            Handle.wireframeColor = Color.clear;
        }

        protected override Matrix4x4 OnGetMatrix()
        {
            return Component.transform.localToWorldMatrix;
        }

        protected override void OnHandleSetup()
        {
            SerializedProperty propertyCenter = SerializedObject.FindProperty("m_center");
            SerializedProperty propertyRadius = SerializedObject.FindProperty("m_radius");

            Handle.center = propertyCenter.vector3Value;
            Handle.radius = propertyRadius.floatValue;
        }

        protected override void OnHandleChanged()
        {
            SerializedProperty propertyCenter = SerializedObject.FindProperty("m_center");
            SerializedProperty propertyRadius = SerializedObject.FindProperty("m_radius");

            propertyCenter.vector3Value = Handle.center;
            propertyRadius.floatValue = Handle.radius;
        }
    }
}
