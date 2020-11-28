using System;

namespace Rectangle.Utility
{
    public class Rectangle<T> where T : struct
    {
        public T SideA { get; }
        public T SideB { get; }

        public Rectangle(T sideA, T sideB)
        {
            SideA = sideA;
            SideB = sideB;
        }

        public T Calculate(Func<T, T, T> calculationLogic)
        {
            return calculationLogic(SideA, SideB);
        }
    }
}
