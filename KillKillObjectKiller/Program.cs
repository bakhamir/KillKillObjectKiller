using System;
using System.Threading;

namespace KillKillObjectKiller
{
    class MyClass
    {
        public MyClass()
        {

        }
        //деструктор или же финализатор
        ~MyClass()
        {
            for (int i = 0; i < 400; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
            
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();

            obj = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine($"tip peremennoi {obj.GetType()}");
        }
    }
}
