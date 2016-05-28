using System;
using DesignPatterns.Infrastructure;

namespace DesignPatterns.DesignPatterns.Structural.Adapter
{
    /// <summary>
    /// https://sourcemaking.com/design_patterns/adapter/java/2
    /// </summary>
    class Example2 : IExample
    {
        public void Run()
        {
            var rh = new RoundHole(5);

            for (var i = 6; i < 10; i++)
            {
                var spa = new SquarePegAdapter(i);
                // The client uses (is coupled to) the new interface
                spa.MakeFit(rh);
            }
        }
    }

    /* The OLD */
    class SquarePeg
    {
        private double _width;

        public SquarePeg(double w)
        {
            _width = w;
        }

        public double GetWidth()
        {
            return _width;
        }

        public void SetWidth(double w)
        {
            _width = w;
        }
    }

    /* The NEW */
    class RoundHole
    {
        private readonly int _radius;

        public RoundHole(int r)
        {
            _radius = r;
            Console.WriteLine("RoundHole: max SquarePeg is " + r * Math.Sqrt(2));
        }

        public int GetRadius()
        {
            return _radius;
        }
    }

    // Design a "wrapper" class that can "impedance match" the old to the new
    class SquarePegAdapter
    {

        // The adapter/wrapper class "has a" instance of the legacy class
        private readonly SquarePeg _sp;

        public SquarePegAdapter(double w) { _sp = new SquarePeg(w); }

        // Identify the desired interface
        public void MakeFit(RoundHole rh)
        {
            // The adapter/wrapper class delegates to the legacy object
            var amount = _sp.GetWidth() - rh.GetRadius() * Math.Sqrt(2);
            Console.WriteLine("reducing SquarePeg " + _sp.GetWidth() + " by " + ((amount < 0) ? 0 : amount) + " amount");

            if (amount > 0)
            {
                _sp.SetWidth(_sp.GetWidth() - amount);
                Console.WriteLine("   width is now " + _sp.GetWidth());
            }
        }
    }
}
