using System;

namespace FiguresAreaLib
{
    public class RightTriangle : IFigure
    {
        private readonly double catheterOne;
        private readonly double catheterTwo;
        private readonly double hypotenuse;

        /// <summary>
        /// Creates right triangle by given catheters
        /// </summary>
        /// <param name="catheterOne">Must be greater than zero</param>
        /// <param name="catheterTwo">Must be greater than zero</param>
        /// <exception cref="ArgumentException">In case if <see cref="catheterOne"/> or <see cref="catheterTwo"/> less than zero</exception>
        public RightTriangle(double catheterOne, double catheterTwo)
        {
            if (catheterOne < 0 || catheterTwo < 0)
            {
                throw new ArgumentException("Length of any of catheters should be greater than zero");
            }

            this.catheterOne = catheterOne;
            this.catheterTwo = catheterTwo;
            this.hypotenuse = Math.Sqrt(catheterOne*catheterOne + catheterTwo*catheterTwo);
        }

        public double GetFigureArea()
        {
            double semiperimeter = (catheterOne + catheterTwo + hypotenuse) / 2;
            return Math.Sqrt(semiperimeter 
                * (semiperimeter - catheterOne) 
                * (semiperimeter - catheterTwo) 
                * (semiperimeter - hypotenuse));
        }
    }
}
