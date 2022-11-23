using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork_ThreadExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //#region Task1
            //Console.WriteLine("Введите первый элемент массива: ");
            //int a = Int32.Parse(Console.ReadLine());
            //Console.WriteLine("Введите последний элемент массива: ");
            //int count = Int32.Parse(Console.ReadLine());
            //List<int> list = new List<int>(count);
            //for (int i = a; i < count; i++) list.Add(i);
            //foreach (var item in list) Console.Write(item + " ");
            //Thread MaxVal = null;
            //Thread MinVal = null;
            //MaxVal = new Thread(new ThreadStart(() =>
            //{
            //    var max = list.Max();
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("\nМаксимальный элемент: " + max);
            //    if (MinVal.ThreadState == ThreadState.Stopped) Console.ResetColor();
            //}));
            //MinVal = new Thread(new ThreadStart(() =>
            //{
            //    var min = list.Min();
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("\nМинимальный элемент: " + min);
            //    if (MaxVal.ThreadState == ThreadState.Stopped) Console.ResetColor();
            //}));
            //MaxVal.Start();
            //MinVal.Start();

            //#endregion 

            //#region Task2
            //static async void CountWord(object data)
            //{
            //    var filename = data as string;
            //    var text = await File.ReadAllTextAsync(filename);
            //    string countSimb = Regex.Replace(text, "[0-9 \n]", "");
            //    Console.WriteLine("Количество символов в тексте без чисел: " + countSimb.Length);
            //}

            //static async void CountNumberOfText(object data)
            //{
            //    var filename = data as string;
            //    var text = await File.ReadAllTextAsync(filename);
            //    string[] numbers = Regex.Split(text, @"\D+");
            //    int countNum = 0;
            //    int sum = 0;
            //    foreach (string value in numbers)
            //    {
            //        if (!string.IsNullOrEmpty(value))
            //        {
            //            int i = Int32.Parse(value);
            //            Console.WriteLine("Number: " + i);
            //            countNum++;
            //            sum += i;
            //        }
            //    }
            //    Console.ForegroundColor = ConsoleColor.Magenta;
            //    Console.WriteLine("Количество чисел в тексте: " + countNum);
            //    Console.WriteLine("Сумма чисел текста: " + sum);
            //    Console.ResetColor();
            //}

            //Task.Run(() => CountNumberOfText("test.txt"));
            //Task.Run(() => CountWord("test.txt"));
            //Console.ReadKey();

            //#endregion

            #region Task3

            Console.WriteLine("Введите первый элемент массива: ");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите последний элемент массива: ");
            int num = Int32.Parse(Console.ReadLine());

            List<int> list = new List<int>(num);
            for (int i = a; i < num; i++) list.Add(i);
            Console.WriteLine();

            Thread Fair = null;
            Thread Positive = null;

            Fair = new Thread(new ThreadStart(() =>
            {
                int countFair = 0;
                foreach (var item in list)
                {
                    if (item % 2 == 0)
                    {
                        countFair++;
                        Console.WriteLine("FairElem: " + item + "; ");
                    }
                }
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\nКоличество чётных элементов: " + countFair + "\n");
                Console.ResetColor();
                if (Positive.ThreadState == ThreadState.Stopped) Console.WriteLine("/--------------------------------------------------------------/");
            }));

            Positive = new Thread(new ThreadStart(() =>
            {
                int countPositive = 0;
                foreach (var item in list)
                {
                    if (item >= 0)
                    {
                        countPositive++;
                        Console.WriteLine("PosElem: " + item + "; ");
                    }
                }
                Console.Write("\n");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n\nКоличество положительных элементов: " + countPositive + "\n");
                Console.ResetColor();
                if (Fair.ThreadState == ThreadState.Stopped) Console.WriteLine("/--------------------------------------------------------------/");
            }));

            Fair.Start();
            Positive.Start();

            #endregion
        }
    }
}
