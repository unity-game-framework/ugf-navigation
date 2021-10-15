using UnityEngine;

namespace UGF.Navigation.Editor
{
    public static class NavMeshEditorUtility
    {
        public static Color GizmoColor { get; } = new Color(0.11F, 0.65F, 0.83F, 1F);
        public static Color GizmoSolidColor { get; } = new Color(0.11F, 0.65F, 0.83F, 0.25F);
        public static Color GizmoWireColor { get; } = new Color(0.11F, 0.65F, 0.83F, 1F);
    }
}
