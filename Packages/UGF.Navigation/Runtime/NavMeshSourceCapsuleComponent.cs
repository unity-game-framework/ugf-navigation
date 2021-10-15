using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Source Capsule", 2000)]
    public class NavMeshSourceCapsuleComponent : NavMeshSourceComponent
    {
        [SerializeField] private Vector3 m_center;
        [SerializeField] private float m_radius = 1F;
        [SerializeField] private float m_height = 2F;

        public Vector3 Center { get { return m_center; } set { m_center = value; } }
        public float Radius { get { return m_radius; } set { m_radius = value; } }
        public float Height { get { return m_height; } set { m_height = value; } }

        protected override NavMeshBuildSource OnBuild()
        {
            return new NavMeshBuildSource
            {
                area = Area,
                shape = NavMeshBuildSourceShape.Capsule,
                transform = Matrix4x4.TRS(m_center, Quaternion.identity, Vector3.one) * transform.localToWorldMatrix,
                size = new Vector3(m_radius * 2F, m_height, 0F),
                component = this
            };
        }
    }
}
