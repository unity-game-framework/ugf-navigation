using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NavMeshBuilder = UnityEngine.AI.NavMeshBuilder;

namespace UGF.Navigation.Runtime.Tests
{
    public class TestNavMeshSurfaceComponent : MonoBehaviour
    {
        [SerializeField] private Bounds m_bounds;
        [NavMeshAgentId]
        [SerializeField] private int m_agentId;
        [NavMeshArea]
        [SerializeField] private int m_area;
        [SerializeField] private LayerMask m_layerMask;
        [SerializeField] private bool m_collect;
        [SerializeField] private NavMeshCollectGeometry m_collectGeometry = NavMeshCollectGeometry.RenderMeshes;
        [SerializeField] private NavMeshData m_data;
        [SerializeField] private List<NavMeshSourceComponent> m_sources = new List<NavMeshSourceComponent>();
        [SerializeField] private List<NavMeshMarkupComponent> m_markups = new List<NavMeshMarkupComponent>();
        [SerializeField] private List<NavMeshLinkComponent> m_links = new List<NavMeshLinkComponent>();

        public Bounds Bounds { get { return m_bounds; } set { m_bounds = value; } }
        public int AgentId { get { return m_agentId; } set { m_agentId = value; } }
        public int Area { get { return m_area; } set { m_area = value; } }
        public LayerMask LayerMask { get { return m_layerMask; } set { m_layerMask = value; } }
        public bool Collect { get { return m_collect; } set { m_collect = value; } }
        public NavMeshCollectGeometry CollectGeometry { get { return m_collectGeometry; } set { m_collectGeometry = value; } }
        public NavMeshData Data { get { return m_data; } set { m_data = value; } }
        public List<NavMeshSourceComponent> Sources { get { return m_sources; } }
        public List<NavMeshMarkupComponent> Markups { get { return m_markups; } }
        public List<NavMeshLinkComponent> Links { get { return m_links; } }

        private NavMeshDataInstance m_instance;
        private List<NavMeshLinkInstance> m_linkInstances = new List<NavMeshLinkInstance>();

        [ContextMenu("Build", false, 2000)]
        public void Build()
        {
            if (m_data != null)
            {
                Clear();
            }

            var sources = new List<NavMeshBuildSource>();
            var markups = new List<NavMeshBuildMarkup>();

            foreach (NavMeshMarkupComponent markup in m_markups)
            {
                markups.Add(markup.Build());
            }

            if (m_collect)
            {
                NavMeshBuilder.CollectSources(NavMeshUtility.GetWorldBounds(m_bounds, transform.position, transform.localRotation, transform.localScale), m_layerMask, m_collectGeometry, m_area, markups, sources);
            }

            foreach (NavMeshSourceComponent source in m_sources)
            {
                sources.Add(source.Build());
            }

            m_data = NavMeshBuilder.BuildNavMeshData(NavMesh.GetSettingsByID(m_agentId), sources, m_bounds, transform.position, transform.rotation);
            m_data.hideFlags = HideFlags.DontSave;

            m_instance = NavMesh.AddNavMeshData(m_data, transform.position, transform.rotation);

            foreach (NavMeshLinkComponent link in m_links)
            {
                m_linkInstances.Add(NavMesh.AddLink(link.Build()));
            }
        }

        [ContextMenu("Clear", false, 2000)]
        public void Clear()
        {
            if (m_data != null)
            {
                NavMesh.RemoveNavMeshData(m_instance);

                foreach (NavMeshLinkInstance instance in m_linkInstances)
                {
                    NavMesh.RemoveLink(instance);
                }

                DestroyImmediate(m_data);

                m_data = null;
                m_instance = default;
                m_linkInstances.Clear();
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
