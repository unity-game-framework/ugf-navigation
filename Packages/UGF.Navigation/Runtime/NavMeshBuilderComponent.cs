using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Builder", 2000)]
    public class NavMeshBuilderComponent : MonoBehaviour
    {
        [SerializeField] private NavMeshDataComponent m_data;
        [NavMeshAgentId]
        [SerializeField] private int m_agentId;
        [SerializeField] private bool m_auto;
        [SerializeField] private List<NavMeshCollectComponent> m_collects = new List<NavMeshCollectComponent>();

        public NavMeshDataComponent Data { get { return m_data; } set { m_data = value; } }
        public int AgentId { get { return m_agentId; } set { m_agentId = value; } }
        public bool Auto { get { return m_auto; } set { m_auto = value; } }
        public List<NavMeshCollectComponent> Collects { get { return m_collects; } }

        public void Build()
        {
            if (m_data.HasInstance)
            {
                m_data.Remove();
            }

            m_data.Data = BuildData();
            m_data.Add();
        }

        public void Clear()
        {
            if (m_data.HasInstance)
            {
                m_data.Remove();
            }
        }

        public NavMeshData BuildData()
        {
            NavMeshBuildSettings settings = NavMesh.GetSettingsByID(m_agentId);
            List<NavMeshBuildSource> sources = CollectSources();

            return NavMeshBuilder.BuildNavMeshData(settings, sources, new Bounds(), transform.position, transform.rotation);
        }

        public List<NavMeshBuildSource> CollectSources()
        {
            var sources = new List<NavMeshBuildSource>();

            CollectSources(sources);

            return sources;
        }

        public void CollectSources(ICollection<NavMeshBuildSource> sources)
        {
            if (sources == null) throw new ArgumentNullException(nameof(sources));

            for (int i = 0; i < m_collects.Count; i++)
            {
                NavMeshCollectComponent collect = m_collects[i];

                collect.Collect(sources);
            }
        }

        private void OnEnable()
        {
            if (m_auto)
            {
                Build();
            }
        }

        private void OnDisable()
        {
            if (m_auto)
            {
                Clear();
            }
        }
    }
}
