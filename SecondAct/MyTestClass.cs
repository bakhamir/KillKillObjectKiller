using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondAct
{

    internal class MyTestClass
    {
        double d, f;
        public MyTestClass(double d, double f)
        {
            this.d = d;
            this.f = f;
        }
        public void Set(int a, int b)
        {
            d = (a + b);
        }
        public double Sum()
        {
            return d + f;
        }
        public void Info()
        {
            Console.WriteLine($"d = {d} f = {f}");
        }
    }
}
