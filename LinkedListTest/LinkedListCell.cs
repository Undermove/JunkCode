using System;
using System.Collections;

namespace LinkedListTest
{
    public class LinkedListCell<T>
    {
        public T Data {get; set;}
        public LinkedListCell<T> Next {get; set;}

        public LinkedListCell(T data)
        {
            Data = data;
        }
    }

    public class LinkedList<T>
    {
        // головная ячейка списка
        public LinkedListCell<T> TopCell { get; private set; }

        public void AddCellToStart(LinkedListCell<T> cell)
        {
            // если список пустой, то просто заполняем первую ячейку
            if(TopCell == null){
                TopCell = cell;
                return;
            }

            // кладём в новую ячейку предыдущую головную ячейку списка
            cell.Next = TopCell;

            // заменяем голову списка на новую
            TopCell = cell;
        }

        public void AddCellToEnd(LinkedListCell<T> lastCell)
        {
            // проверяем, что у нас вообще есть головная ячейка и если нет, то заполняем её
            if(TopCell == null){
                TopCell = lastCell;
                return;
            }

            // бежим по ячейкам до самого конца списка. тут чем больше у нас элементов, тем дольше и сложнее бежать
            var currentCell = TopCell;
            while (currentCell.Next != null)
            {
                currentCell = currentCell.Next;
            }

            currentCell.Next = lastCell;
        }

        public int Count()
        {
            int result = 0;
            var currentCell = TopCell;
            while(currentCell != null){
                result += 1;
                currentCell = currentCell.Next;
            }

            return result;
        }
    }
}


