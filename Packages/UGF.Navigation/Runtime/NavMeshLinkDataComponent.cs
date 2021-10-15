﻿using System;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Link Data", 2000)]
    public class NavMeshLinkDataComponent : MonoBehaviour
    {
        [SerializeField] private NavMeshLinkComponent m_data;
        [SerializeField] private bool m_auto;

        public NavMeshLinkComponent Data { get { return m_data; } set { m_data = value; } }
        public bool Auto { get { return m_auto; } set { m_auto = value; } }
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

        private void OnEnable()
        {
            if (m_auto && m_instance == null)
            {
                Add();
            }
        }

        private void OnDisable()
        {
            if (m_auto)
            {
                Remove();
            }
        }
    }
}
