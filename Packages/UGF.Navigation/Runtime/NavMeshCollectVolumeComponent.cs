using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Collect Volume", 2000)]
    public class NavMeshCollectVolumeComponent : NavMeshCollectBuilderComponent
    {
        [SerializeField] private Vector3 m_center;
        [SerializeField] private Vector3 m_size = Vector3.one;

        public Vector3 Center { get { return m_center; } set { m_center = value; } }
        public Vector3 Size { get { return m_size; } set { m_size = value; } }

        protected override void OnCollect(ICollection<NavMeshBuildSource> sources)
        {
            Bounds bounds = NavMeshUtility.GetWorldBounds(new Bounds(m_center, m_size), transform.position, transform.rotation, transform.localScale);
            List<NavMeshBuildMarkup> markups = GetMarkups();
            var results = new List<NavMeshBuildSource>();

            NavMeshBuilder.CollectSources(bounds, LayerMask, CollectType, DefaultArea, markups, results);

            for (int i = 0; i < results.Count; i++)
            {
                sources.Add(results[i]);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(m_center, m_size);
        }
    }
}
