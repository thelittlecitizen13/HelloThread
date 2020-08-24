using System;
using System.Threading;

namespace HelloThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        public static void PrintWord(string word, int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("The word is: " + word);
            }
        }

        static void Print1000times()
        {
            Thread t1 = new Thread(() => PrintWord("mamas", 1000));
            Thread t2 = new Thread(() => PrintWord("Empire", 1000));
            t1.IsBackground = true;
            t2.IsBackground = true;
            t1.Start();
            t2.Start();
        }
    }
}
