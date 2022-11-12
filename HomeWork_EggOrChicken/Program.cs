using System;
using System.Threading;

namespace HomeWork_EggOrChicken
{
    class Program
    {
        static Thread chickenVoice;
        static Thread eggVoice;
        static int count = 0;
        static void Main(string[] args)
        {
            chickenVoice = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(new Random().Next(100, 500));
                    Console.WriteLine(count++ + ") Chicken # " + i);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("+++++++++++++++++++++++++++++++Конец потока Chicken+++++++++++++++++++++++++++++++++++++++++");
                Console.ResetColor();
                if (eggVoice.ThreadState == ThreadState.Stopped) Console.WriteLine("Первым было яйцо");
            }));

            eggVoice = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(new Random().Next(100, 500));
                    Console.WriteLine(count++ + ") Egg! # " + i);
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("+++++++++++++++++++++++++++++++Конец потока Egg+++++++++++++++++++++++++++++++++++++++++++++");
                Console.ResetColor();
                if (chickenVoice.ThreadState == ThreadState.Stopped) Console.WriteLine("Первым была курица");
            }));
            eggVoice.Start();
            chickenVoice.Start();
        }
    }
}
