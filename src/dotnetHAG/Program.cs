using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace dotnetHAG
{
    class Program
    {
        static void Main(string[] args)
        {
            Version ver = VersionChecker.GetDotnetVersion();
            Console.WriteLine($"Your dotnet version: {ver}");
            Console.ReadLine();
        }
    }
}
