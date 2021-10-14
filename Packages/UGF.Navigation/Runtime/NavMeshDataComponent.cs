﻿using System;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Data", 2000)]
    public class NavMeshDataComponent : MonoBehaviour
    {
        [SerializeField] private NavMeshData m_data;

        public NavMeshData Data { get { return m_data; } set { m_data = value; } }
        public NavMeshDataInstance Instance { get { return m_instance ?? throw new ArgumentException("Value not specified."); } }
        public bool HasInstance { get { return m_instance != null; } }

        private NavMeshDataInstance? m_instance;

        public void Add()
        {
            if (m_instance != null) throw new InvalidOperationException("NavMesh Data already added.");

            m_instance = NavMesh.AddNavMeshData(m_data, transform.position, transform.rotation);
        }

        public bool Remove()
        {
            if (m_instance != null)
            {
                NavMesh.RemoveNavMeshData(m_instance.Value);

                m_instance = null;

                return true;
            }

            return false;
        }

        private void OnEnable()
        {
            if (m_instance == null)
            {
                Add();
            }
        }

        private void OnDisable()
        {
            Remove();
        }
    }
}
