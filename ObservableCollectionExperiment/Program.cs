using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableCollectionExperiment
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<string> observableCollection = new ObservableCollection<string>();

            for (int i = 0; i < 10; i++)
            {
                observableCollection.Add(i.ToString());
            }

            observableCollection.Insert(1, "Inserted to intex 1");

            observableCollection.Add("AddedItem");

            foreach (string s in observableCollection)
            {
                Console.WriteLine(s);
            }

            observableCollection.Insert(observableCollection.Count + 3, "Inserted to intex empty");

            Console.ReadKey();
        }
    }
}
