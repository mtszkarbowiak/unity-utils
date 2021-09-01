using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UnityUtils
{
    public static class Extensions
    {
        public static int DestroyAllChildren(this Transform transform)
        {
            var childCount = transform.childCount;

            for(var i = childCount - 1; i >= 0; i--)
            {
                Object.Destroy(transform.GetChild(i).gameObject);
            }

            return childCount;
        }
        
        public static int DestroyAllChildren(this GameObject gameObject)
        {
            var transform = gameObject.transform;
            var childCount = transform.childCount;

            for(var i = childCount - 1; i >= 0; i--)
            {
                Object.Destroy(transform.GetChild(i).gameObject);
            }

            return childCount;
        }
        
        public static void FindShaderMetadata(this MonoBehaviour target, params ComputeShader[] shaders)
        {
            if (shaders.Length < 1) throw new ArgumentException("Finding metadata for 0 shaders makes no sense.");
            
            var fields = target
                .GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            
            foreach (var field in fields)
            {
                var attributes =  field.GetCustomAttributes(false);
                
                var shaderPropertyHashAttribute = attributes
                        .FirstOrDefault(x => x is ShaderPropertyHashAttribute)
                    as ShaderPropertyHashAttribute;
                
                if(shaderPropertyHashAttribute != null)
                {
                    var value = Shader.PropertyToID(shaderPropertyHashAttribute.PropertyName);

                    field.SetValue(target, value);
                }
                
                var shaderKernelAttribute = attributes
                        .FirstOrDefault(x => x is ShaderKernelAttribute)
                    as ShaderKernelAttribute;
                
                if(shaderKernelAttribute != null)
                {
                    var value = shaders[shaderKernelAttribute.ShaderIndex].FindKernel(shaderKernelAttribute.KernelName);

                    field.SetValue(target, value);
                }
            }
        }
    }
}