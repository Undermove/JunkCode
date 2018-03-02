using System;

namespace FiguresAreaLib
{
    public class Circle : IFigure
    {
        private readonly double radius;

        /// <summary>
        /// Creates simple circle with specified radius
        /// </summary>
        /// <param name="radius">Radius. Must be greater than zero</param>
        /// <exception cref="ArgumentException">In case if <see cref="radius"/> less than zero</exception>
        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentException($"Radius should be greater than zero");
            }

            this.radius = radius;
        }

        public double GetFigureArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }
    }
}
