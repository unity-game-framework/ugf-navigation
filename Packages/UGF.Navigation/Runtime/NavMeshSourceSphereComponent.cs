using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Source Sphere", 2000)]
    public class NavMeshSourceSphereComponent : NavMeshSourceComponent
    {
        [SerializeField] private Vector3 m_center;
        [SerializeField] private float m_radius = 1F;

        public Vector3 Center { get { return m_center; } set { m_center = value; } }
        public float Radius { get { return m_radius; } set { m_radius = value; } }

        protected override NavMeshBuildSource OnBuild()
        {
            return new NavMeshBuildSource
            {
                area = Area,
                shape = NavMeshBuildSourceShape.Sphere,
                transform = Matrix4x4.TRS(m_center, Quaternion.identity, Vector3.one) * transform.localToWorldMatrix,
                size = Vector3.one * m_radius * 2F,
                component = this
            };
        }
    }
}
