using UnityEngine;

namespace UGF.Navigation.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestNavMeshAttributesAsset")]
    public class TestNavMeshAttributesAsset : ScriptableObject
    {
        [NavMeshAgentId]
        [SerializeField] private int m_agentId;
        [NavMeshAreaMask]
        [SerializeField] private int m_areaMask;
        [NavMeshArea]
        [SerializeField] private int m_area;

        public int AgentId { get { return m_agentId; } set { m_agentId = value; } }
        public int AreaMask { get { return m_areaMask; } set { m_areaMask = value; } }
        public int Area { get { return m_area; } set { m_area = value; } }
    }
}
