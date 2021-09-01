using System.Collections.Generic;
using UnityEngine;

namespace UnityUtils
{
    public static class Mathf2
    {
        public static Range CreateRangeFromSet(IEnumerable<float> set)
        {
            var min = float.MaxValue;
            var max = float.MinValue;
            
            foreach (var f in set)
            {
                if (f < min) min = f;
                if (f > max) max = f;
            }
            
            return new Range(min, max);
        }

        public static Rect CreateRectFromSet(IEnumerable<Vector2> set)
        {
            var minX = float.MaxValue;
            var maxX = float.MinValue;
            var minY = float.MaxValue;
            var maxY = float.MinValue;
            
            foreach (var v in set)
            {
                if (v.x < minX) minX = v.x;
                if (v.x > maxX) maxX = v.x;
                if (v.y < minY) minY = v.y;
                if (v.y > maxY) maxY = v.y;
            }

            var deltaX = maxX - minX;
            var deltaY = maxY - minY;
            
            return new Rect(minX, minY, deltaX, deltaY);
        }

        public static Bounds CreateBoundsFromSet(IEnumerable<Vector3> set)
        {
            var minX = float.MaxValue;
            var maxX = float.MinValue;
            var minY = float.MaxValue;
            var maxY = float.MinValue;
            var minZ = float.MaxValue;
            var maxZ = float.MinValue;
            
            foreach (var v in set)
            {
                if (v.x < minX) minX = v.x;
                if (v.x > maxX) maxX = v.x;
                if (v.y < minY) minY = v.y;
                if (v.y > maxY) maxY = v.y;
                if (v.z < minZ) minZ = v.z;
                if (v.z > maxZ) maxZ = v.z;
            }

            var deltaX = maxX - minX;
            var deltaY = maxY - minY;
            var deltaZ = maxZ - minZ;

            var centerX = minX + deltaX / 2;
            var centerY = minY + deltaY / 2;
            var centerZ = minZ + deltaZ / 2;

            var size = new Vector3(deltaX, deltaY, deltaZ);
            var center = new Vector3(centerX, centerY, centerZ);
            
            return new Bounds(center, size);
        }
    }
}