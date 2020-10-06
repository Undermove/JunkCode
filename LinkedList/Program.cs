using System.Threading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinkedListTest;

namespace LinkedList {
    class Program {
        static void Main (string[] args) {
            LinkedListTest.LinkedList<int> linkedList = new LinkedListTest.LinkedList<int> ();

            Int64 iterationsCount = 0;
            try {
                List<Task> tasks = new List<Task> ();
                for (int i = 0; i < 4; i++) {
                    Thread thread = Thread.
                    tasks.Add (
                        Task.Factory.StartNew (() => {
                            while (true) {
                                linkedList.AddCellToEnd (new LinkedListCell<int> (6));
                                iterationsCount++;
                                Console.WriteLine ($"Iteration: {iterationsCount}");
                            }
                        })
                    );
                }
                Console.ReadLine();
            } catch (OutOfMemoryException) {
                Console.WriteLine ($"IterationsCount is {iterationsCount}");
                throw;
            }
        }
    }
}