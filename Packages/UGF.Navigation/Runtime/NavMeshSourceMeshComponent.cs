using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Source Mesh", 2000)]
    public class NavMeshSourceMeshComponent : NavMeshSourceComponent
    {
        [SerializeField] private Mesh m_mesh;

        public Mesh Mesh { get { return m_mesh; } set { m_mesh = value; } }

        protected override NavMeshBuildSource OnBuild()
        {
            return new NavMeshBuildSource
            {
                area = Area,
                shape = NavMeshBuildSourceShape.Mesh,
                transform = transform.localToWorldMatrix,
                size = m_mesh.bounds.size,
                component = this,
                sourceObject = m_mesh
            };
        }
    }
}
