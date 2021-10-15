﻿using System;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace UGF.Navigation.Editor.EditorTools
{
    internal abstract class ComponentEditorTool : EditorTool
    {
        public SerializedObject SerializedObject { get { return m_serializedObject ?? throw new ArgumentException("Value not specified."); } }
        public Component Component { get { return m_component ? m_component : throw new ArgumentException("Value not specified."); } }

        private SerializedObject m_serializedObject;
        private Component m_component;

        public override void OnActivated()
        {
            base.OnActivated();

            m_serializedObject = new SerializedObject(target);
            m_component = (Component)target;
        }

        public override void OnWillBeDeactivated()
        {
            base.OnWillBeDeactivated();

            m_serializedObject?.Dispose();
            m_serializedObject = null;
            m_component = null;
        }

        public override void OnToolGUI(EditorWindow window)
        {
            base.OnToolGUI(window);

            if (m_serializedObject != null && m_component != null)
            {
                OnToolGUI();
            }
        }

        protected abstract void OnToolGUI();
    }
}