using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Source Modifier Box", 2000)]
    public class NavMeshSourceModifierBoxComponent : NavMeshSourceComponent
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
                transform = transform.localToWorldMatrix * Matrix4x4.TRS(m_center, Quaternion.identity, Vector3.one),
                size = Vector3.Scale(m_size, transform.localScale),
                component = this
            };
        }
    }
}
