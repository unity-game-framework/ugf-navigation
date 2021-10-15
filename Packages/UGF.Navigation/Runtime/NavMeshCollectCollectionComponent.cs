using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Collect Collection", 2000)]
    public class NavMeshCollectCollectionComponent : NavMeshCollectComponent
    {
        [SerializeField] private List<NavMeshSourceComponent> m_sources = new List<NavMeshSourceComponent>();

        public List<NavMeshSourceComponent> Sources { get { return m_sources; } }

        protected override void OnCollect(ICollection<NavMeshBuildSource> sources)
        {
            for (int i = 0; i < m_sources.Count; i++)
            {
                NavMeshSourceComponent component = m_sources[i];
                NavMeshBuildSource source = component.Build();

                sources.Add(source);
            }
        }
    }
}
