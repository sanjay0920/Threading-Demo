namespace ManualResetEventdemo
{
    internal class Program
    {
        static ManualResetEvent _manual = new ManualResetEvent(false);
        
        static void Main(string[] args)
        {
            Thread t2 = new Thread(Write);
            t2.Name = "Sanjay";
            t2.Start();
            for (int i = 0; i < 5; i++)
            {
           
                Thread t1 = new Thread(Read);
                t1.Name = String.Concat("Thread -", i);
                t1.Start();
            }
            Console.ReadKey();
        }
        public static void Write()
        {

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} starts writing");
            _manual.Reset();
            string k = Thread.CurrentThread.Name + " is reading\n";
            File.AppendAllText("threadwriting.txt", k);
            Thread.Sleep(1000);
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} writing completed");
            _manual.Set();
        }
        public static void Read()
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} waiting to Read");
            _manual.WaitOne();
           
            string[] lines = File.ReadAllLines("threadwriting.txt");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Reading completed");
         
        }
    }
}