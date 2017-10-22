using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoupListTest
{
    class Program
    {
        private static List<ComponentWithTwoProperties> list = new List<ComponentWithTwoProperties>();

        static void Main(string[] args)
        {
            list.Add(new ComponentWithTwoProperties() {Name = "Chart",Value = "1"});
            list.Add(new ComponentWithTwoProperties() {Name = "Chart",Value = "1"});
            list.Add(new ComponentWithTwoProperties() {Name = "Main",Value = "1"});
            list.Add(new ComponentWithTwoProperties() {Name = "Level2",Value = "1"});
            list.Add(new ComponentWithTwoProperties() {Name = "Clock",Value = "1"});

            List<IGrouping<string, ComponentWithTwoProperties>> groupedList = list.GroupBy(properties => properties.Name).ToList();

            foreach (IGrouping<string, ComponentWithTwoProperties> component in groupedList)
            {
                Console.WriteLine($"{component.Key} {component.Count()}");
            }

            Console.ReadLine();
        }
    }

    class ComponentWithTwoProperties
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
