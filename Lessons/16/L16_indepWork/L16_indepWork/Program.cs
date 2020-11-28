using System;
using Calculator.Figure;
using Calculator.Operation;

namespace L16_indepWork
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = 1.5;
            var c1 = new Circle(radius);

            var output = new CalculatorOperation();
            output.Write(radius, c1);
        }
    }
}
