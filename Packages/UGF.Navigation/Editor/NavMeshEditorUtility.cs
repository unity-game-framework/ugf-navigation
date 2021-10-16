using UnityEngine;

namespace UGF.Navigation.Editor
{
    public static class NavMeshEditorUtility
    {
        public static Color HandlersEnabledColor { get; } = new Color(0.13F, 0.5F, 0.63F);
        public static Color HandlersDisabledColor { get; } = new Color(0.13F, 0.5F, 0.63F, 0.3F);
        public static Color HandlersSolidColor { get; } = new Color(0.13F, 0.5F, 0.63F, 0.5F);
        public static Color HandlersControlColor { get; } = new Color(0.19F, 0.81F, 1F);
    }
}
