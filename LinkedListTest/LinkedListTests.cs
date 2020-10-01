using System;
using Xunit;

namespace LinkedListTest
{
    public class LinkedListTest
    {
        [Fact]
        public void AddCellToStartTest()
        {
            // arrange
            LinkedList<int> list = new LinkedList<int>();
            var lastCell = new LinkedListCell<int>(1);

            // act
            list.AddCellToStart(lastCell);

            // assert
            Assert.Equal(1, list.Count());
        }

        [Fact]
        public void AddTwoCellsToStartTest()
        {
            // arrange
            LinkedList<int> list = new LinkedList<int>();
            var firstCell = new LinkedListCell<int>(1);
            var lastCell = new LinkedListCell<int>(1);

            // act
            list.AddCellToStart(firstCell);
            list.AddCellToStart(lastCell);

            // assert
            Assert.Equal(2, list.Count());
        }

        [Fact]
        public void AddCellToEndTest()
        {
            // arrange
            LinkedList<int> list = new LinkedList<int>();
            var firstCell = new LinkedListCell<int>(1);

            // act
            list.AddCellToEnd(firstCell);

            // assert
            Assert.Equal(1, list.Count());
        }

        [Fact]
        public void AddSecondCellToEndTest()
        {
            // arrange
            LinkedList<int> list = new LinkedList<int>();
            var firstCell = new LinkedListCell<int>(1);
            list.AddCellToEnd(firstCell);
            var lastCell = new LinkedListCell<int>(1);

            // act
            list.AddCellToEnd(lastCell);

            // assert
            Assert.Same(firstCell, list.TopCell);
            Assert.Same(lastCell, list.TopCell.Next);
        }

        [Fact]
        public void AddThreeCellsToEndTest()
        {
            // arrange
            LinkedList<int> list = new LinkedList<int>();
            var firstCell = new LinkedListCell<int>(1);
            var secondCell = new LinkedListCell<int>(1);
            var thirdCell = new LinkedListCell<int>(1);

            // act
            list.AddCellToEnd(firstCell);
            list.AddCellToEnd(secondCell);
            list.AddCellToEnd(thirdCell);

            // assert
            Assert.Same(firstCell, list.TopCell);
            Assert.Same(secondCell, list.TopCell.Next);
            Assert.Same(thirdCell, list.TopCell.Next.Next);
        }
    }
}