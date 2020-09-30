using System;
using Xunit;

namespace LinkedListTest
{
    public class UnitTest1
    {
        [Fact]
        public void LinkedListTest1()
        {
            // Arrange
            LinkedListCell<int> firstCell = new LinkedListCell<int>(1);
            LinkedListCell<int> secondCell = new LinkedListCell<int>(2);
            LinkedListCell<int> thirdCell = new LinkedListCell<int>(3);
            LinkedListCell<int> fourthCell = new LinkedListCell<int>(4);
            LinkedListCell<int> fifthCell = new LinkedListCell<int>(5);

            firstCell.Next = secondCell;
            secondCell.Next = thirdCell;
            thirdCell.Next = fourthCell;
            fourthCell.Next = fifthCell;
            fifthCell.Next = null;

            // Act
            int result = 0;
            var currentCell = firstCell;
            while(currentCell != null){
                result += currentCell.Data;
                currentCell = currentCell.Next;
            }

            // Assert
            Assert.Equal(result, 15);
        }
    }
}
