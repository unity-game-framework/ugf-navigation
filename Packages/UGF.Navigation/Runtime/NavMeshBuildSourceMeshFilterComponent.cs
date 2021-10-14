using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Build Source MeshFilter")]
    public class NavMeshBuildSourceMeshFilterComponent : NavMeshBuildSourceComponent
    {
        [SerializeField] private MeshFilter m_meshFilter;

        public MeshFilter MeshFilter { get { return m_meshFilter; } set { m_meshFilter = value; } }

        protected override NavMeshBuildSource OnBuild()
        {
            return new NavMeshBuildSource
            {
                area = Area,
                shape = NavMeshBuildSourceShape.Mesh,
                transform = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale),
                size = m_meshFilter.sharedMesh.bounds.size,
                component = this,
                sourceObject = m_meshFilter.sharedMesh
            };
        }
    }
}
