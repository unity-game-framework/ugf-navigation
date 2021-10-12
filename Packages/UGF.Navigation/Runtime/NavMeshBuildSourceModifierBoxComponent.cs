using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Build Source Modifier Box", 2000)]
    public class NavMeshBuildSourceModifierBoxComponent : NavMeshBuildSourceComponent
    {
        [SerializeField] private Bounds m_bounds;

        public Bounds Bounds { get { return m_bounds; } set { m_bounds = value; } }

        protected override NavMeshBuildSource OnBuild()
        {
            Bounds bounds = NavigationUtility.GetWorldBounds(m_bounds, Vector3.zero, Quaternion.identity, Vector3.one);

            return new NavMeshBuildSource
            {
                area = Area,
                shape = NavMeshBuildSourceShape.ModifierBox,
                transform = Matrix4x4.TRS(m_bounds.center, transform.rotation, Vector3.one),
                size = bounds.size,
                component = this
            };
        }
    }
}
