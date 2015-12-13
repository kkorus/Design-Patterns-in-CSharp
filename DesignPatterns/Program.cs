using DesignPatterns.Infrastructure;
using Structural = DesignPatterns.DesignPatterns.Structural;
using Creational = DesignPatterns.DesignPatterns.Creational;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            IExample example = new Structural.Adapter.Example1();
            example.Run();
        }
    }
}
