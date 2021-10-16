using System;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Data", 2000)]
    public class NavMeshDataComponent : MonoBehaviour
    {
        [SerializeField] private bool m_addOnStart;
        [SerializeField] private NavMeshData m_data;

        public bool AddOnStart { get { return m_addOnStart; } set { m_addOnStart = value; } }
        public NavMeshData Data { get { return m_data; } set { m_data = value; } }
        public NavMeshDataInstance Instance { get { return m_instance ?? throw new ArgumentException("Value not specified."); } }
        public bool HasInstance { get { return m_instance != null; } }

        private NavMeshDataInstance? m_instance;

        public void Add()
        {
            if (m_instance != null) throw new InvalidOperationException("NavMesh Data already added.");

            m_instance = NavMesh.AddNavMeshData(m_data);
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

        private void Start()
        {
            if (m_addOnStart)
            {
                Add();
            }
        }

        private void OnDestroy()
        {
            Remove();
        }
    }
}
