﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClass;
using MyExtensions;
using SomeCodeWithCSharp.Scripts.Pair;
using SomeCodeWithCSharp.Scripts.Event;

namespace SomeCodeWithCSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            //MLinq.TestLinq();
            //MLinq.TestLinqSuper_Join();
            //Pair.Instance.Start();
            EventTest.Instance.Test();
            Console.ReadLine();
        }

        

        private static void TestFather()
        {
            Father fa = new Father(21, "Darcy", new Position(12, 12));

            Console.WriteLine(fa.SaySomething("Hello my good son"));
            Console.ReadLine();
        }
    }
}
