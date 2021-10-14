using UGF.Builder.Runtime;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Markup", 2000)]
    public class NavMeshMarkupComponent : BuilderComponent<NavMeshBuildMarkup>
    {
        [SerializeField] private bool m_overrideArea;
        [NavMeshArea]
        [SerializeField] private int m_area;
        [SerializeField] private bool m_ignoreFromBuild;

        public bool OverrideArea { get { return m_overrideArea; } set { m_overrideArea = value; } }
        public int Area { get { return m_area; } set { m_area = value; } }
        public bool IgnoreFromBuild { get { return m_ignoreFromBuild; } set { m_ignoreFromBuild = value; } }

        protected override NavMeshBuildMarkup OnBuild()
        {
            return new NavMeshBuildMarkup
            {
                overrideArea = m_overrideArea,
                area = m_area,
                ignoreFromBuild = m_ignoreFromBuild,
                root = transform
            };
        }
    }
}
