using System;
using System.Threading;
namespace SemaphoreDemo
{
class program
{
    static Thread[] threads = new Thread[5];
    static Semaphore sem = new Semaphore(3, 3);
    static void main()
    {
        Console.WriteLine("{0} is waiting in line...", Thread.CurrentThread.Name);
        sem.WaitOne();
        Console.WriteLine("{0} enters  ", Thread.CurrentThread.Name);
        Thread.Sleep(300);
        Console.WriteLine("{0} is leaving  ", Thread.CurrentThread.Name);
        sem.Release();
    }
    static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            threads[i] = new Thread(main);
            threads[i].Name = "thread_" + i;
            threads[i].Start();
        }
        Console.Read();
    }
}
}