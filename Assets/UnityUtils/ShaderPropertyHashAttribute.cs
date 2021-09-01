using System;

namespace UnityUtils
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false), Serializable]
    public sealed class ShaderPropertyHashAttribute : Attribute
    {
        public readonly string PropertyName;
        
        public ShaderPropertyHashAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}