using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    public abstract class NavMeshCollectBuilderComponent : NavMeshCollectComponent
    {
        [SerializeField] private LayerMask m_layerMask = 1;
        [NavMeshArea]
        [SerializeField] private int m_defaultArea;
        [SerializeField] private NavMeshCollectGeometry m_collectType = NavMeshCollectGeometry.RenderMeshes;
        [SerializeField] private List<NavMeshMarkupComponent> m_markups = new List<NavMeshMarkupComponent>();

        public LayerMask LayerMask { get { return m_layerMask; } set { m_layerMask = value; } }
        public int DefaultArea { get { return m_defaultArea; } set { m_defaultArea = value; } }
        public NavMeshCollectGeometry CollectType { get { return m_collectType; } set { m_collectType = value; } }
        public List<NavMeshMarkupComponent> Markups { get { return m_markups; } }

        public List<NavMeshBuildMarkup> GetMarkups()
        {
            var markups = new List<NavMeshBuildMarkup>();

            GetMarkups(markups);

            return markups;
        }

        public void GetMarkups(ICollection<NavMeshBuildMarkup> markups)
        {
            if (markups == null) throw new ArgumentNullException(nameof(markups));

            for (int i = 0; i < m_markups.Count; i++)
            {
                NavMeshMarkupComponent component = m_markups[i];
                NavMeshBuildMarkup markup = component.Build();

                markups.Add(markup);
            }
        }
    }
}
