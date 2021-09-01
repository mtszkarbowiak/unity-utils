using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace UnityUtils
{
    [StructLayout(LayoutKind.Sequential), Serializable]
    public struct Range
    {
        public float Min, Max;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Range(float min, float max)
        {
            Min = min;
            Max = max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Range Create(float min = float.MinValue, float max = float.MaxValue)
        {
            return new Range(min, max);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Range CreateFromSet(IEnumerable<float> set)
        {
            return Mathf2.CreateRangeFromSet(set);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Range CreateFromDistance(float center, float distance)
        {
            var rangeHalved = distance / 2f;
            var min = center - rangeHalved;
            var max = center + rangeHalved;

            return new Range(min, max);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Contains(float f)
        {
            return f >= Min && f <= Max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ContainsExclusive(float f)
        {
            return f > Min && f < Max;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float Lerp(float t)
        {
            return Mathf.Lerp(Min, Max, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsValid()
        {
            return Max >= Min;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsEmpty()
        {
            return Max <= Min;
        }

        public float Center
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (Min + Max) / 2f;
        }

        public float Span
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Max - Min;
        }

        public override string ToString()
        {
            return $"({Min},{Max})";
        }
    }
}