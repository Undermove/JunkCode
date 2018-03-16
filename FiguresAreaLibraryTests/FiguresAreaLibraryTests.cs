using System;
using FiguresAreaLib;
using Xunit;

namespace FiguresAreaLibraryTests
{
    public class FiguresAreaLibraryTests
    {
        [Fact]
        public void RightTriangleAreaCorrectCalculationTest()
        {
            // Arrange
            IFigure figure = new RightTriangle(3, 4);

            // Act
            double area = figure.GetFigureArea();

            // Assert
            Assert.Equal(6, area);
        }

        [Fact]
        public void RigthTriangleWithNegativeCatheterOneCreationTest()
        {
            // Arrange
            double catheterOne = -3;
            double catheterTwo = 4;

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                IFigure figure = new RightTriangle(catheterOne, catheterTwo);
            });
        }

        [Fact]
        public void RigthTriangleWithNegativeCatheterTwoCreationTest()
        {
            // Arrange
            double catheterOne = 3;
            double catheterTwo = -4;

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                IFigure figure = new RightTriangle(catheterOne, catheterTwo);
            });
        }

        [Fact]
        public void CircleAreaCorrectCalculationTest()
        {
            // Arrange
            double expectedRadius = 1;
            double tolerance = 1E-10;
            IFigure figure = new Circle(Math.Sqrt(1 / Math.PI));

            // Act
            double area = figure.GetFigureArea();

            // Assert
            Assert.InRange(Math.Abs(area - expectedRadius), double.Epsilon, tolerance);
        }

        [Fact]
        public void CircleWithNegativeRadiusCreationTest()
        {
            // Arrange
            double radius = -3;

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                IFigure figure = new Circle(radius);
            });
        }
    }
}
