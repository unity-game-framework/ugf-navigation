using System;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    public static class NavMeshView
    {
        public static bool Display
        {
            get { return m_display; }
            set
            {
                if (m_display != value)
                {
                    m_display = value;

                    if (value)
                    {
                        if (m_triangulation == null)
                        {
                            Update();
                        }

                        Camera.onPostRender += m_handler;
                    }
                    else
                    {
                        Camera.onPostRender -= m_handler;
                    }
                }
            }
        }

        public static NavMeshTriangulation Triangulation { get { return m_triangulation ?? throw new ArgumentException("Value not specified."); } }
        public static bool HasTriangulation { get { return m_triangulation != null; } }

        private static readonly Material m_material;
        private static readonly Camera.CameraCallback m_handler;
        private static bool m_display;
        private static NavMeshTriangulation? m_triangulation;

        static NavMeshView()
        {
            m_material = new Material(Shader.Find("Hidden/Internal-Colored"));
            m_handler = OnRender;
        }

        public static void SetTriangulation(NavMeshTriangulation triangulation)
        {
            m_triangulation = triangulation;
        }

        public static void ClearTriangulation()
        {
            m_triangulation = null;
        }

        public static void Update()
        {
            m_triangulation = NavMesh.CalculateTriangulation();
        }

        private static void OnRender(Camera _)
        {
            if (m_display && m_triangulation != null)
            {
                NavMeshUtility.DrawNavMesh(m_triangulation.Value, m_material);
            }
        }
    }
}
