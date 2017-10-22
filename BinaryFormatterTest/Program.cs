using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BinaryFormatterTest
{
    [Serializable]
    class Bot
    {
        private Guid age;

        public Guid Age
        {
            get { return age; }
        }

        public Bot()
        {
            this.age = Guid.NewGuid();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Preparing test data.");

            List<Bot> botList = new List<Bot>();

            for (int i = 0; i < 1; i++)
            {
                botList.Add(new Bot());
            }

            Console.WriteLine("Start BinarySerialization");
            Stopwatch sw = Stopwatch.StartNew();
            BinaryFormatter bf = new BinaryFormatter();
            string path = @"D:\1\bin.dat";

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, botList);;
            }

            Console.WriteLine("Complete in {0}", sw.ElapsedMilliseconds);
            sw.Reset();

            
            sw.Start();
            Console.WriteLine("Start JsonSerialization");
            string pathJ = @"D:\1\bin.json";
            JsonSerializer js = new JsonSerializer();

            using (StreamWriter fs = File.CreateText(pathJ))
            {
                js.Serialize(fs, botList); ;
            }

            Console.WriteLine("Complete in {0}", sw.ElapsedMilliseconds);
            

            Console.ReadKey();

            Console.WriteLine("Start Deserializing from Json");
            sw.Reset();
            sw.Start();

            using (StreamReader file = File.OpenText(pathJ))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<Bot> movie2 = (List<Bot>)serializer.Deserialize(file, typeof(List<Bot>));
            }

            Console.WriteLine("Complete in {0}", sw.ElapsedMilliseconds);

            Console.WriteLine("Start Deserializing from Binary");
            sw.Reset();
            sw.Start();

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                bf = new BinaryFormatter();
                List<Bot> botListDeserialized = (List<Bot>)bf.Deserialize(fs);
            }

            Console.WriteLine("Complete in {0}", sw.ElapsedMilliseconds);

            Console.ReadKey();
        }
    }
}
