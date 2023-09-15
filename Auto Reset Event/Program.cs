namespace AutoResetEventDemo
{
    internal class Program
    {
        static AutoResetEvent _auto = new AutoResetEvent(true);
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(Write).Start();
            }
           

            Console.ReadKey();
        }
        public static void Write()
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} is waiting");
            _auto.WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} starts writing");
            Thread.Sleep(1000);
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} writing completed");
            _auto.Set();

        }
    }
}