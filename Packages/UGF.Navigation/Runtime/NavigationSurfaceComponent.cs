using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/Navigation Surface", 2000)]
    public class NavigationSurfaceComponent : MonoBehaviour
    {
        [SerializeField] private Bounds m_bounds;
        [NavMeshAgentType]
        [SerializeField] private int m_agentType;
        [NavMeshArea]
        [SerializeField] private int m_areaMask;
        [SerializeField] private LayerMask m_layerMask;
        [SerializeField] private NavMeshCollectGeometry m_collectGeometry = NavMeshCollectGeometry.RenderMeshes;
        [SerializeField] private NavMeshData m_data;

        public Bounds Bounds { get { return m_bounds; } set { m_bounds = value; } }
        public int AgentType { get { return m_agentType; } set { m_agentType = value; } }
        public int AreaMask { get { return m_areaMask; } set { m_areaMask = value; } }
        public LayerMask LayerMask { get { return m_layerMask; } set { m_layerMask = value; } }
        public NavMeshCollectGeometry CollectGeometry { get { return m_collectGeometry; } set { m_collectGeometry = value; } }
        public NavMeshData Data { get { return m_data; } set { m_data = value; } }

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

            NavMeshBuilder.CollectSources(NavigationUtility.GetWorldBounds(m_bounds, transform.position, transform.localRotation, transform.localScale), m_layerMask, m_collectGeometry, m_areaMask, markups, sources);

            m_data = NavMeshBuilder.BuildNavMeshData(NavMesh.GetSettingsByID(m_agentType), sources, m_bounds, transform.position, transform.rotation);
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
    }
}
