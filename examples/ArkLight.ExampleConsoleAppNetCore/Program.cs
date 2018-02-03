using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Reactive.Linq;

using ArkLight.Collection;
using ArkLight.Util;

namespace ArkLight.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var doubleList = new List<List<double>>()
            {
                new List<double> {1,2,3 },
                new List<double> {4,5,6,23,4,5 },
                new List<double> {7,8,9 },
            };
            var list = new double[] { 1, 1, 2, 3, 4, 5, 6, 44 }.ToObservable();
            var x = from score in list where score > 8 select score;
            Console.WriteLine(x.ToString());
            var dic = new Dictionary<string, int>()
            {
                { "sss" ,1},
                { "sa" ,1},
                { "s1" ,1},
            };
            foreach(var item in doubleList)
            {
                Console.WriteLine(item.ToListString());
            }
            Console.WriteLine(dic.ToKeyValuePairString());
            Console.WriteLine("Hello World!");
            Console.WriteLine(RegexUtil.IsIdCard("140521********08050018"));
            Console.ReadLine();
        }
    }

}
