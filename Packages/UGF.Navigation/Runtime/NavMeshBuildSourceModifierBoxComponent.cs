using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Build Source Modifier Box", 2000)]
    public class NavMeshBuildSourceModifierBoxComponent : NavMeshBuildSourceComponent
    {
        [SerializeField] private Vector3 m_center;
        [SerializeField] private Vector3 m_size = Vector3.one;

        public Vector3 Center { get { return m_center; } set { m_center = value; } }
        public Vector3 Size { get { return m_size; } set { m_size = value; } }

        protected override NavMeshBuildSource OnBuild()
        {
            return new NavMeshBuildSource
            {
                area = Area,
                shape = NavMeshBuildSourceShape.ModifierBox,
                transform = Matrix4x4.TRS(transform.position + m_center, transform.rotation, Vector3.one),
                size = new Vector3(m_size.x * transform.localScale.x, m_size.y * transform.localScale.y, m_size.z * transform.localScale.z),
                component = this
            };
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(m_center, m_size);
        }
    }
}
