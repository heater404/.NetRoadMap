using System;
using System.Diagnostics;

namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic dyP = Activator.CreateInstance(typeof(Person), new object[] { "张含韵" });
            object  obP= Activator.CreateInstance(typeof(Person), new object[] { "张含韵" });

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                string name = dyP.GetName();
            }
            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds);

            stopwatch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                string name = (string)(obP.GetType().GetMethod("GetName")).Invoke(obP,null); 
            }
            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds);
        }
    }

    public class Person
    {
        private string name;
        public Person(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
