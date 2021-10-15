﻿using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Source Box", 2000)]
    public class NavMeshSourceBoxComponent : NavMeshSourceComponent
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
                shape = NavMeshBuildSourceShape.Box,
                transform = Matrix4x4.TRS(m_center, Quaternion.identity, Vector3.one) * transform.localToWorldMatrix,
                size = m_size,
                component = this
            };
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.matrix = Matrix4x4.TRS(m_center, Quaternion.identity, Vector3.one) * transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, m_size);
        }
    }
}
