using System.Collections;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityUtils;

namespace UnityUtilsTests
{
    public class Mathf2Tests
    {
        [Test]
        public void CreateRangeFromSet_Normal()
        {
            var resultMin = -9.5f;
            var resultMax = 9.5f;
            var input = new float[]{ resultMax, 3f, 0f, resultMin };
            var range = Mathf2.CreateRangeFromSet(input);
            
            Assert.AreEqual(range.Min, resultMin);
            Assert.AreEqual(range.Max, resultMax);
        }
        
        [Test]
        public void CreateRangeFromSet_EmptyInput()
        {
            var result = Mathf2.CreateRangeFromSet(Enumerable.Empty<float>());

            Assert.IsFalse(result.IsValid());
            Assert.Pass();
        }
        
        [Test]
        public void Range_IsValid_Case_D0()
        {
            Assert.IsTrue(new Range(0,0).IsValid());
        }
        
        [Test]
        public void Range_IsValid_Case_DN()
        {
            Assert.IsFalse(new Range(10,-10).IsValid());
        }
    }
}
