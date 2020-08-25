using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;

namespace HelloThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            //Print1000times(); // Ex 2
            PrintByCounter(); // EX 3
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
        public static void PrintWord(string word, int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("The word is: " + word);
            }
        }


        static int mamasCounter = 0;
        static int empireCounter = 0;
        static int counter = 0;
        static object obj = new object();


        static void PrintByCounter()
        {
            for (int i = 0; i < 2; i++)
            {
                int num = i;
                Thread t = new Thread(() => PrintByThread(num));
                t.Start();   
            }
        }

        static void PrintByThread(int threadNumber)
        {
                while (counter < 3000)
                {
                if (threadNumber == 0 && (counter % 2 == 0))
                {
                    Console.WriteLine("mamas");
                    lock (obj)
                    {
                        counter++;
                        mamasCounter++;
                    }
                }
                else
                {
                    if (threadNumber == 1 && (counter % 2 != 0))
                    {
                        Console.WriteLine("empire");
                        lock (obj)
                        {
                            counter++;
                            empireCounter++;
                        }
                    }
                }

                    }
                
            Console.WriteLine("Mamas: " + mamasCounter);
            Console.WriteLine("Empire: " + empireCounter);
        }
    }
}
