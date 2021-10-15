using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor.EditorTools
{
    internal abstract class ComponentEditorTool : EditorTool
    {
        protected SerializedObject SerializedObject { get; private set; }
        protected Component Component { get; private set; }

        public override void OnActivated()
        {
            base.OnActivated();

            SerializedObject = new SerializedObject(target);
            Component = (Component)target;
        }

        public override void OnWillBeDeactivated()
        {
            base.OnWillBeDeactivated();

            SerializedObject?.Dispose();
            SerializedObject = null;
            Component = null;
        }

        public override void OnToolGUI(EditorWindow window)
        {
            base.OnToolGUI(window);

            if (SerializedObject != null)
            {
                OnToolGUI();
            }
        }

        protected abstract void OnToolGUI();
    }
}
