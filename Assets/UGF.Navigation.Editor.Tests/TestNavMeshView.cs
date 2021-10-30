using UGF.Navigation.Runtime;
using UnityEditor;

namespace UGF.Navigation.Editor.Tests
{
    public static class TestNavMeshView
    {
        [MenuItem("Tests/NavMeshView Display", false, 2000)]
        private static void DisplayMenu()
        {
            NavMeshView.Display = !NavMeshView.Display;

            Menu.SetChecked("Tests/NavMeshView Display", NavMeshView.Display);
        }

        [MenuItem("Tests/NavMeshView Display", true, 2000)]
        private static bool DisplayValidate()
        {
            return EditorApplication.isPlaying;
        }
    }
}
