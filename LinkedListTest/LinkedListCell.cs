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
}


