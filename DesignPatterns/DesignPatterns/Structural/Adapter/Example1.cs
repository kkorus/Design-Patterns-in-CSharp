using System;
using System.Collections.Generic;
using DesignPatterns.Infrastructure;

namespace DesignPatterns.DesignPatterns.Structural.Adapter
{
    /// <summary>
    /// http://www.codeproject.com/Articles/774259/Adapter-Design-Pattern-Csharp
    /// </summary>
    public class Example1 : IExample
    {
        public void Run()
        {
            ITarget adapter = new VendorAdapter();
            foreach (var product in adapter.GetProducts())
            {
                Console.WriteLine(product);
            }

            Console.ReadLine();
        }
    }

    public interface ITarget
    {
        List<string> GetProducts();
    }

    public class VendorAdaptee
    {
        public List<string> GetListOfProducts()
        {
            var products = new List<string> { "Gaming Consoles", "Television", "Books", "Musical Instruments" };
            return products;
        }
    }

    public class VendorAdapter : ITarget
    {
        public List<string> GetProducts()
        {
            var adaptee = new VendorAdaptee();
            return adaptee.GetListOfProducts();
        }
    }
}