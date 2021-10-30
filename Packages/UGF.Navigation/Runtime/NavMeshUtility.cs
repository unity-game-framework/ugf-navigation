using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UGF.Navigation.Runtime
{
    public static class NavMeshUtility
    {
        public static Bounds GetWorldBounds(Bounds bounds, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            Matrix4x4 matrix = Matrix4x4.TRS(position, rotation, scale);

            return GetWorldBounds(bounds, matrix);
        }

        public static Bounds GetWorldBounds(Bounds bounds, Matrix4x4 matrix)
        {
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

        public static Color GetAreaColor(int index)
        {
            if (index == 0)
            {
                return new Color(0F, 0.75F, 1F, 0.5F);
            }

            float r = (Bit(index, 4) + Bit(index, 1) * 2 + 1) * 63F / byte.MaxValue;
            float g = (Bit(index, 3) + Bit(index, 2) * 2 + 1) * 63F / byte.MaxValue;
            float b = (Bit(index, 5) + Bit(index, 0) * 2 + 1) * 63F / byte.MaxValue;

            return new Color(r, g, b, 0.5F);
        }

        public static void DrawNavMesh(NavMeshTriangulation triangulation, Material material)
        {
            DrawNavMesh(triangulation.vertices, triangulation.indices, triangulation.areas, material);
        }

        public static void DrawNavMesh(IReadOnlyList<Vector3> vertices, IReadOnlyList<int> indices, IReadOnlyList<int> areas, Material material)
        {
            if (vertices == null) throw new ArgumentNullException(nameof(vertices));
            if (indices == null) throw new ArgumentNullException(nameof(indices));
            if (areas == null) throw new ArgumentNullException(nameof(areas));
            if (material == null) throw new ArgumentNullException(nameof(material));

            GL.PushMatrix();
            GL.MultMatrix(Matrix4x4.identity);
            GL.Begin(GL.TRIANGLES);

            material.SetPass(0);

            for (int i = 0; i < indices.Count; i += 3)
            {
                GL.Color(GetAreaColor(areas[i / 3]));
                GL.Vertex(vertices[indices[i]]);
                GL.Vertex(vertices[indices[i + 1]]);
                GL.Vertex(vertices[indices[i + 2]]);
            }

            GL.End();
            GL.Begin(GL.LINES);

            material.SetPass(0);

            GL.Color(Color.black);

            for (int i = 0; i < indices.Count; i += 3)
            {
                GL.Vertex(vertices[indices[i]]);
                GL.Vertex(vertices[indices[i + 1]]);
                GL.Vertex(vertices[indices[i + 1]]);
                GL.Vertex(vertices[indices[i + 2]]);
                GL.Vertex(vertices[indices[i + 2]]);
                GL.Vertex(vertices[indices[i]]);
            }

            GL.End();
            GL.PopMatrix();
        }

        private static int Bit(int a, int b)
        {
            return (a & 1 << b) >> b;
        }
    }
}
