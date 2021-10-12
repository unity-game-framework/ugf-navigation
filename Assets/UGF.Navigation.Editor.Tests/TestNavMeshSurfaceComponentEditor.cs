using System;
using UGF.Navigation.Runtime.Tests;
using UnityEditor;
using UnityEditor.AI;

namespace UGF.Navigation.Editor.Tests
{
    [CustomEditor(typeof(TestNavMeshSurfaceComponent), true)]
    public class TestNavMeshSurfaceComponentEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            NavMeshVisualizationSettings.showNavigation++;
        }

        private void OnDisable()
        {
            NavMeshVisualizationSettings.showNavigation--;
        }
    }
}
