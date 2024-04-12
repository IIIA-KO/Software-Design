﻿using DemoClassLibrary;
using DemoConsoleApp.Demos;

namespace DemoConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Demo> demos =
            [
                //new CompositeDemo(),
                //new StrategyDemo(),
                //new ObserverDemo(),
                new TemplateMethodDemo(),
            ];

            demos.ForEach(d => d.Run());
        }
    }
}