using System;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Link Data", 2000)]
    public class NavMeshLinkDataComponent : MonoBehaviour
    {
        [SerializeField] private bool m_addOnStart;
        [SerializeField] private NavMeshLinkComponent m_data;

        public bool AddOnStart { get { return m_addOnStart; } set { m_addOnStart = value; } }
        public NavMeshLinkComponent Data { get { return m_data; } set { m_data = value; } }
        public NavMeshLinkInstance Instance { get { return m_instance ?? throw new ArgumentException("Value not specified."); } }
        public bool HasInstance { get { return m_instance != null; } }

        private NavMeshLinkInstance? m_instance;

        public void Add()
        {
            if (m_instance != null) throw new InvalidOperationException("NavMesh Link Data already added.");

            NavMeshLinkData data = m_data.Build();

            m_instance = NavMesh.AddLink(data);
        }

        public bool Remove()
        {
            if (m_instance != null)
            {
                NavMesh.RemoveLink(m_instance.Value);

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
