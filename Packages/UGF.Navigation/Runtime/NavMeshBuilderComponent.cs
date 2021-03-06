using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Builder", 2000)]
    public class NavMeshBuilderComponent : MonoBehaviour
    {
        [SerializeField] private bool m_buildOnStart;
        [SerializeField] private Vector3 m_center;
        [SerializeField] private Vector3 m_size = Vector3.one;
        [NavMeshAgentId]
        [SerializeField] private int m_agent;
        [SerializeField] private NavMeshDataComponent m_data;
        [SerializeField] private List<NavMeshCollectComponent> m_collects = new List<NavMeshCollectComponent>();

        public bool BuildOnStart { get { return m_buildOnStart; } set { m_buildOnStart = value; } }
        public Vector3 Center { get { return m_center; } set { m_center = value; } }
        public Vector3 Size { get { return m_size; } set { m_size = value; } }
        public int Agent { get { return m_agent; } set { m_agent = value; } }
        public NavMeshDataComponent Data { get { return m_data; } set { m_data = value; } }
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

                Destroy(m_data.Data);

                m_data.Data = null;
            }
        }

        public NavMeshData BuildData()
        {
            NavMeshBuildSettings settings = NavMesh.GetSettingsByID(m_agent);
            List<NavMeshBuildSource> sources = CollectSources();
            Vector3 center = Vector3.Scale(m_center, transform.localScale);
            Vector3 size = Vector3.Scale(m_size, transform.localScale);
            var bounds = new Bounds(center, size);

            NavMeshData data = NavMeshBuilder.BuildNavMeshData(settings, sources, bounds, transform.position, transform.rotation);

            data.name = "NavMeshData";

            return data;
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

        private void Start()
        {
            if (m_buildOnStart)
            {
                Build();
            }
        }

        private void OnDestroy()
        {
            Clear();
        }
    }
}
