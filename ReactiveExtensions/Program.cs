using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReactiveExtensions
{
    class Program
    {

        static void Main(string[] args)
        {
        }

        class GeneratingCollectionClass
        {
            private ObservableCollection<string> strings = new ObservableCollection<string>();

            public GeneratingCollectionClass()
            {
                Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        strings.Add(i.ToString());
                        Thread.Sleep(100);
                    }
                });
            }
        }

        class CustomerClass
        {
            
        }
    }
}
