using System;
using System.Threading;
namespace  Threading
{ 
    class Program {

        static void Main() 
        { 
            
            Thread SecondaryThread = new Thread(new ThreadStart(print));
            SecondaryThread.Start();

           for (int i = 0; i<10; i++)
            {
                Console.WriteLine($"Primary Thread:{i}");
                Thread.Sleep(1000);
            }
           
            
                Thread t;
                t = Thread.CurrentThread;
                Console.WriteLine("Thread is Alive or Not: {0}", t.IsAlive);
                Thread.Sleep(10000);

            
            Console.ReadKey();

            }
        static void print()
        {
            for (int i = 11; i < 20; i++) {
                Console.WriteLine($"SecondaryThread:{i}");
                Thread.Sleep(1000);
                    }
        }
        
        }
}
