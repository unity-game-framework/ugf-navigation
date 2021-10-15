#if UGF_MODULE_TERRAIN_ENABLED
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Source Terrain", 2000)]
    public class NavMeshSourceTerrainComponent : NavMeshSourceComponent
    {
        [SerializeField] private Terrain m_terrain;

        public Terrain Terrain { get { return m_terrain; } set { m_terrain = value; } }

        protected override NavMeshBuildSource OnBuild()
        {
            Transform terrainTransform = m_terrain.transform;
            TerrainData terrainData = m_terrain.terrainData;

            return new NavMeshBuildSource
            {
                area = Area,
                shape = NavMeshBuildSourceShape.Terrain,
                transform = terrainTransform.localToWorldMatrix,
                size = terrainData.size,
                component = this,
                sourceObject = terrainData
            };
        }
    }
}
#endif
