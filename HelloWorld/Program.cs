using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = 10;
            Incrementa(a);
            Console.WriteLine("a: " + a);
            //a = IncrementaERitorna(a);
            Console.WriteLine("a: " + IncrementaERitorna(a));
        }

        private static void Incrementa(int v) 
        {
            int x = 1;
            v = v + x;
            Console.WriteLine("v: " + v);            
        }

        private static int IncrementaERitorna(int v) {
            int x = 1;
            v = v + x;
            Console.WriteLine("v:" + v);
            return v;
        }
        
    }
}
