﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavMeshBuilder = UnityEngine.AI.NavMeshBuilder;

namespace UGF.Navigation.Runtime.Tests
{
    public class TestNavMeshSurfaceComponent : MonoBehaviour
    {
        [SerializeField] private Bounds m_bounds;
        [NavMeshAgentType]
        [SerializeField] private int m_agentType;
        [NavMeshArea]
        [SerializeField] private int m_area;
        [SerializeField] private LayerMask m_layerMask;
        [SerializeField] private NavMeshCollectGeometry m_collectGeometry = NavMeshCollectGeometry.RenderMeshes;
        [SerializeField] private NavMeshData m_data;
        [SerializeField] private List<NavMeshBuildSourceComponent> m_sources = new List<NavMeshBuildSourceComponent>();
        [SerializeField] private List<NavMeshBuildMarkupComponent> m_markups = new List<NavMeshBuildMarkupComponent>();

        public Bounds Bounds { get { return m_bounds; } set { m_bounds = value; } }
        public int AgentType { get { return m_agentType; } set { m_agentType = value; } }
        public int Area { get { return m_area; } set { m_area = value; } }
        public LayerMask LayerMask { get { return m_layerMask; } set { m_layerMask = value; } }
        public NavMeshCollectGeometry CollectGeometry { get { return m_collectGeometry; } set { m_collectGeometry = value; } }
        public NavMeshData Data { get { return m_data; } set { m_data = value; } }
        public List<NavMeshBuildSourceComponent> Sources { get { return m_sources; } }
        public List<NavMeshBuildMarkupComponent> Markups { get { return m_markups; } }

        private NavMeshDataInstance m_instance;

        [ContextMenu("Build", false, 2000)]
        public void Build()
        {
            if (m_data != null)
            {
                Clear();
            }

            var sources = new List<NavMeshBuildSource>();
            var markups = new List<NavMeshBuildMarkup>();

            // NavMeshBuilder.CollectSources(NavigationUtility.GetWorldBounds(m_bounds, transform.position, transform.localRotation, transform.localScale), m_layerMask, m_collectGeometry, m_areaMask, markups, sources);

            foreach (NavMeshBuildSourceComponent source in m_sources)
            {
                sources.Add(source.Build());
            }

            foreach (NavMeshBuildMarkupComponent markup in m_markups)
            {
                markups.Add(markup.Build());
            }

            m_data = NavMeshBuilder.BuildNavMeshData(NavMesh.GetSettingsByID(m_agentType), sources, m_bounds, transform.position, transform.rotation);
            m_data.hideFlags = HideFlags.DontSave;

            m_instance = NavMesh.AddNavMeshData(m_data, transform.position, transform.rotation);
        }

        [ContextMenu("Clear", false, 2000)]
        public void Clear()
        {
            if (m_data != null)
            {
                NavMesh.RemoveNavMeshData(m_instance);

                DestroyImmediate(m_data);

                m_data = null;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(m_bounds.center, m_bounds.size);
        }
    }
}