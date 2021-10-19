using System;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace UGF.Navigation.Editor.EditorTools
{
    internal abstract class ComponentBoundsShapeEditorTool<THandle> : ComponentEditorTool where THandle : PrimitiveBoundsHandle
    {
        public THandle Handle { get; }
        public override GUIContent toolbarIcon { get { return ComponentEditorToolUtility.EditSizeContent; } }

        protected ComponentBoundsShapeEditorTool(THandle handle)
        {
            Handle = handle ?? throw new ArgumentNullException(nameof(handle));
        }

        protected abstract Matrix4x4 OnGetMatrix();
        protected abstract void OnHandleSetup();
        protected abstract void OnHandleChanged();

        protected override void OnToolGUI()
        {
            using (new SerializedObjectUpdateScope(SerializedObject))
            {
                Matrix4x4 matrix = OnGetMatrix();

                using (new Handles.DrawingScope(matrix))
                {
                    OnHandleSetup();

                    using (var scope = new EditorGUI.ChangeCheckScope())
                    {
                        Handle.DrawHandle();

                        if (scope.changed)
                        {
                            OnHandleChanged();
                        }
                    }
                }
            }
        }
    }
}
