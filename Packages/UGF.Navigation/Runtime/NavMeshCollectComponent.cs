using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    public abstract class NavMeshCollectComponent : MonoBehaviour
    {
        public void Collect(ICollection<NavMeshBuildSource> sources)
        {
            if (sources == null) throw new ArgumentNullException(nameof(sources));

            OnCollect(sources);
        }

        protected abstract void OnCollect(ICollection<NavMeshBuildSource> sources);
    }
}
