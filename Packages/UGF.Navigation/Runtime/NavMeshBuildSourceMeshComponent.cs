using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Build Source Mesh", 2000)]
    public class NavMeshBuildSourceMeshComponent : NavMeshBuildSourceComponent
    {
        [SerializeField] private Mesh m_mesh;

        public Mesh Mesh { get { return m_mesh; } set { m_mesh = value; } }

        protected override NavMeshBuildSource OnBuild()
        {
            return new NavMeshBuildSource
            {
                area = Area,
                shape = NavMeshBuildSourceShape.Mesh,
                transform = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale),
                size = m_mesh.bounds.size,
                component = this,
                sourceObject = m_mesh
            };
        }
    }
}
