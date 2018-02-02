using System;

using ArkLight.Util;

namespace ArkLight.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(RegexUtil.IsIdCard("140521********08050018"));
            Console.ReadLine();
        }
    }
}
