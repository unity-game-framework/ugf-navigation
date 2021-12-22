using UGF.EditorTools.Editor.Assets;
using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Navigation.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Editor
{
    [CustomEditor(typeof(NavMeshBuilderComponent), true)]
    internal class NavMeshBuilderComponentEditor : UnityEditor.Editor
    {
        private readonly GUIContent m_contentEdit = new GUIContent("Edit Bounds");
        private SerializedProperty m_propertyBuildOnStart;
        private SerializedProperty m_propertyCenter;
        private SerializedProperty m_propertySize;
        private SerializedProperty m_propertyAgent;
        private SerializedProperty m_propertyData;
        private ReorderableListDrawer m_listCollects;
        private NavMeshBuilderComponent m_component;

        private void OnEnable()
        {
            m_propertyBuildOnStart = serializedObject.FindProperty("m_buildOnStart");
            m_propertyCenter = serializedObject.FindProperty("m_center");
            m_propertySize = serializedObject.FindProperty("m_size");
            m_propertyAgent = serializedObject.FindProperty("m_agent");
            m_propertyData = serializedObject.FindProperty("m_data");
            m_listCollects = new ReorderableListDrawer(serializedObject.FindProperty("m_collects"));
            m_listCollects.Enable();
            m_component = (NavMeshBuilderComponent)target;
        }

        private void OnDisable()
        {
            m_listCollects.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                EditorGUILayout.PropertyField(m_propertyBuildOnStart);

                EditorGUILayout.EditorToolbarForTarget(m_contentEdit, target);
                EditorGUILayout.Space(EditorGUIUtility.standardVerticalSpacing);

                EditorGUILayout.PropertyField(m_propertyCenter);
                EditorGUILayout.PropertyField(m_propertySize);
                EditorGUILayout.PropertyField(m_propertyAgent);
                EditorGUILayout.PropertyField(m_propertyData);

                m_listCollects.DrawGUILayout();

                EditorGUILayout.Space();

                using (new EditorGUILayout.HorizontalScope())
                {
                    GUILayout.FlexibleSpace();

                    using (new EditorGUI.DisabledScope(m_propertyData.objectReferenceValue == null))
                    {
                        var dataComponent = (NavMeshDataComponent)m_propertyData.objectReferenceValue;

                        using (new EditorGUI.DisabledScope(dataComponent == null || dataComponent.Data == null))
                        {
                            if (GUILayout.Button("Clear", GUILayout.Width(75F)))
                            {
                                OnClear();
                            }
                        }

                        if (GUILayout.Button("Build", GUILayout.Width(75F)))
                        {
                            OnBuild();
                        }
                    }

                    EditorGUILayout.Space();
                }

                EditorGUILayout.Space();
            }
        }

        private bool HasFrameBounds()
        {
            return true;
        }

        private Bounds OnGetFrameBounds()
        {
            return NavMeshEditorUtility.GetTargetWorldBounds(target, m_propertyCenter.vector3Value, m_propertySize.vector3Value);
        }

        private void OnBuild()
        {
            var dataComponent = (NavMeshDataComponent)m_propertyData.objectReferenceValue;
            string assetPath = string.Empty;

            if (dataComponent.Data != null)
            {
                assetPath = AssetDatabase.GetAssetPath(dataComponent.Data);

                OnClear();
            }

            NavMeshData data = m_component.BuildData();

            if (string.IsNullOrEmpty(assetPath))
            {
                if (AssetsEditorUtility.TrySelectDirectory("Select Directory", "Assets", true, out string directory) && AssetDatabase.IsValidFolder(directory))
                {
                    assetPath = AssetDatabase.GenerateUniqueAssetPath($"{directory}/NavMeshData.asset");
                }
            }

            if (!string.IsNullOrEmpty(assetPath))
            {
                AssetDatabase.CreateAsset(data, assetPath);

                Undo.RegisterCompleteObjectUndo(dataComponent, "Create NavMesh Data");
                Undo.RegisterCreatedObjectUndo(data, "Create NavMesh Data");

                dataComponent.Data = data;
            }
        }

        private void OnClear()
        {
            var dataComponent = (NavMeshDataComponent)m_propertyData.objectReferenceValue;

            Undo.RegisterCompleteObjectUndo(dataComponent, "Clear NavMesh Data");

            dataComponent.Data = null;
        }
    }
}
