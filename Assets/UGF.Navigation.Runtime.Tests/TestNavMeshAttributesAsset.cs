﻿using UnityEngine;

namespace UGF.Navigation.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestNavMeshAttributesAsset")]
    public class TestNavMeshAttributesAsset : ScriptableObject
    {
        [NavMeshAgentType]
        [SerializeField] private int m_agentType;
        [NavMeshAreaMask]
        [SerializeField] private int m_areaMask;
        [NavMeshArea]
        [SerializeField] private int m_area;

        public int AgentType { get { return m_agentType; } set { m_agentType = value; } }
        public int AreaMask { get { return m_areaMask; } set { m_areaMask = value; } }
        public int Area { get { return m_area; } set { m_area = value; } }
    }
}
