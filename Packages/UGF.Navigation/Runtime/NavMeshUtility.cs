using UnityEngine;

namespace UGF.Navigation.Runtime
{
    public static class NavMeshUtility
    {
        public static Bounds GetWorldBounds(Bounds bounds, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            Matrix4x4 matrix = Matrix4x4.TRS(position, rotation, scale);

            Vector3 center = matrix.MultiplyPoint3x4(bounds.center);
            Vector3 extents = bounds.extents;

            Vector3 axisX = matrix.MultiplyVector(new Vector3(extents.x, 0F, 0F));
            Vector3 axisY = matrix.MultiplyVector(new Vector3(0F, extents.y, 0F));
            Vector3 axisZ = matrix.MultiplyVector(new Vector3(0F, 0F, extents.z));

            extents.x = Mathf.Abs(axisX.x) + Mathf.Abs(axisY.x) + Mathf.Abs(axisZ.x);
            extents.y = Mathf.Abs(axisX.y) + Mathf.Abs(axisY.y) + Mathf.Abs(axisZ.y);
            extents.z = Mathf.Abs(axisX.z) + Mathf.Abs(axisY.z) + Mathf.Abs(axisZ.z);

            return new Bounds { center = center, extents = extents };
        }
    }
}
