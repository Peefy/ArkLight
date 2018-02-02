using System;
using System.Collections.Generic;
using System.Text;

using ArkLight.Collection;
using ArkLight.Util;

namespace ArkLight.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RegexUtil.IsEmail("123@qq.com"));
            Console.ReadLine();
        }
    }
}
