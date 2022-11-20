using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HomeWork_ThreadExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первый элемент массива: ");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите последний элемент массива: ");
            int count = Int32.Parse(Console.ReadLine());
            List<int> list = new List<int>(count);
            for (int i = a; i < count; i++) list.Add(i);
            foreach (var item in list) Console.Write(item + " ");
            Thread MaxVal = null;
            Thread MinVal = null;
            MaxVal = new Thread(new ThreadStart(() =>
            {
                var max = list.Max();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nМаксимальный элемент: " + max);
               if(MinVal.ThreadState == ThreadState.Stopped) Console.ResetColor();
            }));
            MinVal = new Thread(new ThreadStart(() =>
            {
                var min = list.Min();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nМинимальный элемент: " + min);
               if(MaxVal.ThreadState == ThreadState.Stopped) Console.ResetColor();
            }));
            MaxVal.Start();
            MinVal.Start();
        }
    }
}
