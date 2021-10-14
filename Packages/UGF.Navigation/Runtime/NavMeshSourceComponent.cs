using UGF.Builder.Runtime;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    public abstract class NavMeshSourceComponent : BuilderComponent<NavMeshBuildSource>
    {
        [NavMeshArea]
        [SerializeField] private int m_area;

        public int Area { get { return m_area; } set { m_area = value; } }
    }
}
