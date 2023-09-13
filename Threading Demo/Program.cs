using System;
using System.Threading;
namespace  Threading
{ 
    class Program { 
        static void Main() 
        { 

            Thread WorkerThread = new Thread(new ThreadStart(print));
            WorkerThread.Start();

           for (int i = 0; i<10; i++)
            {
                Console.WriteLine($"main Thread:{i}");
                Thread.Sleep(1000);
            }
              Console.ReadKey();

            }
        static void print()
        {
            for (int i = 11; i < 20; i++) {
                Console.WriteLine($"WorkerThread:{i}");
                Thread.Sleep(1000);
                    }
        }
        }
}
