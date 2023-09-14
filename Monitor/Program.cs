namespace MonitorDemo
{
    class Program
    {
        static readonly object _object = new object();

        public static void PrintNumbers()
        {
            Monitor.Enter(_object);
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(i + ",");
                }
                Console.WriteLine();
            }
            finally
            {
                Monitor.Exit(_object);
            }
        }

    
        static void Main(string[] args)
        {


            Thread[] Threads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                Threads[i] = new Thread(new ThreadStart(PrintNumbers));
                Threads[i].Name = "Child " + i;
            }
            foreach (Thread t in Threads)
                t.Start();

            Console.ReadLine();
        }
    }
}