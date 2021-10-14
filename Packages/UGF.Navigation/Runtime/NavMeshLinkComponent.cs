using UGF.Builder.Runtime;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    [AddComponentMenu("Unity Game Framework/Navigation/NavMesh Link", 2000)]
    public class NavMeshLinkComponent : BuilderComponent<NavMeshLinkData>
    {
        [NavMeshArea]
        [SerializeField] private int m_area;
        [NavMeshAgentId]
        [SerializeField] private int m_agentType;
        [SerializeField] private Vector3 m_start;
        [SerializeField] private Vector3 m_end = Vector3.forward;
        [SerializeField] private float m_width = 1F;
        [SerializeField] private float m_cost = 1F;
        [SerializeField] private bool m_bidirectional = true;

        public int Area { get { return m_area; } set { m_area = value; } }
        public int AgentType { get { return m_agentType; } set { m_agentType = value; } }
        public Vector3 Start { get { return m_start; } set { m_start = value; } }
        public Vector3 End { get { return m_end; } set { m_end = value; } }
        public float Width { get { return m_width; } set { m_width = value; } }
        public float Cost { get { return m_cost; } set { m_cost = value; } }
        public bool Bidirectional { get { return m_bidirectional; } set { m_bidirectional = value; } }

        protected override NavMeshLinkData OnBuild()
        {
            return new NavMeshLinkData
            {
                area = m_area,
                agentTypeID = m_agentType,
                startPosition = transform.TransformPoint(m_start),
                endPosition = transform.TransformPoint(m_end),
                width = m_width,
                costModifier = m_cost,
                bidirectional = m_bidirectional
            };
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawCube(m_start, Vector3.one * 0.1F);
            Gizmos.DrawCube(m_end, Vector3.one * 0.1F);
        }
    }
}
