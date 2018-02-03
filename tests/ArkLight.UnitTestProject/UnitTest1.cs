using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using ArkLight.Collection;

namespace ArkLight.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ArkLightCollectionTest()
        {
            var doubleList = new List<List<double>>()
            {
                new List<double> {1,2,3 },
                new List<double> {4,5,6,23,4,5 },
                new List<double> {7,8,9 },
            };
            var list = new double[] { 1, 1, 2, 3, 4, 5, 6, 44 };
            var x = from score in list where score > 8 select score;
            var dic = new Dictionary<string, int>()
            {
                { "sss" ,1},
                { "sa" ,1},
                { "s1" ,1},
            };
            Assert.AreEqual("{\"sss\" : 1, \"sa\" : 1, \"s1\" : 1}", dic.ToKeyValuePairString());
            var items = new ObservableRangeCollection<int>();
            items.AddRange(new int[] { 1, 2, 3 });
            Assert.AreEqual(1, items[0]);
        }

    }
}
