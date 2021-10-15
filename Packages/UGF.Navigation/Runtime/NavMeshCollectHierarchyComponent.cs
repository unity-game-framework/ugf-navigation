using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Collect Hierarchy", 2000)]
    public class NavMeshCollectHierarchyComponent : NavMeshCollectBuilderComponent
    {
        [SerializeField] private Transform m_root;

        public Transform Root { get { return m_root; } set { m_root = value; } }

        protected override void OnCollect(ICollection<NavMeshBuildSource> sources)
        {
            List<NavMeshBuildMarkup> markups = GetMarkups();
            var results = new List<NavMeshBuildSource>();

            NavMeshBuilder.CollectSources(m_root, LayerMask, CollectType, DefaultArea, markups, results);

            for (int i = 0; i < results.Count; i++)
            {
                sources.Add(results[i]);
            }
        }
    }
}
