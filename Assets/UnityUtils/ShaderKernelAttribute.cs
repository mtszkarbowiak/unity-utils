using System;

namespace UnityUtils
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false), Serializable]
    public sealed class ShaderKernelAttribute : Attribute
    {
        public readonly string KernelName;
        public readonly int ShaderIndex;
        
        public ShaderKernelAttribute(string kernelName, int shaderIndex = 0)
        {
            KernelName = kernelName;
            ShaderIndex = shaderIndex;
        }
    }
}