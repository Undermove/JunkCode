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
                    // создал четрые таски с параметрами запуска LongRunning 
                    // чтобы они запустились каждая в своём потоке и максимально 
                    // эффективно загрузили мой 4-х ядерный процессор
                    tasks.Add (
                        Task.Factory.StartNew (() => {
                            while (true) {
                                linkedList.AddCellToEnd (new LinkedListCell<int> (6));
                                iterationsCount++;
                                Console.WriteLine ($"Iteration: {iterationsCount}");
                            }
                        }, TaskCreationOptions.LongRunning)
                    );
                }
                Console.ReadLine();
            } catch (OutOfMemoryException) {
                // жду пока у моего компа не закончится память, точнее пока не закончится память, которую ОС может выделить под мой процесс
                // Обычно в таком случае приложуха выбрасывает OutOfMemoryException, которую я и перехватываю строчкой выше
                // записываю в консоль количество добавленных ячеек
                Console.WriteLine ($"IterationsCount is {iterationsCount}");
                throw;
            }
        }
    }
}