using System;
using System.Collections;
using System.Threading;
namespace MutexDemo
{
    class program
    {
        private static Mutex mutex = new Mutex();
        private const int numhits = 1;
        private const int numThreads = 4;
        private static void ThreadProcess()
        {
            for (int i = 0; i < numhits; i++)
            {
                print();
            }
        }
        private static void print()
        {
            mutex.WaitOne();   // Wait until it is safe to enter.  
            Console.WriteLine("{0} has entered", Thread.CurrentThread.Name);
            
            Thread.Sleep(500);    // Wait until it is safe to enter.  
            Console.WriteLine("{0} is leaving", Thread.CurrentThread.Name);
            mutex.ReleaseMutex();    // Release the Mutex.  
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < numThreads; i++)
            {
                Thread mycorner = new Thread(new ThreadStart(ThreadProcess));
                mycorner.Name = String.Format("Thread{0}", i + 1);
                mycorner.Start();
            }
            Console.Read();
        }
    }
}
