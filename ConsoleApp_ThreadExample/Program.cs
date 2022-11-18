using System;
using System.Threading;

namespace ConsoleApp_ThreadExample
{

    class Program
    {
        static void Main(string[] args)
        {
            // Thread - Поток это интсрумент операционный системы который может
            //содержать в себе некий набор последовательности инструкции для выполнения процессором.
            //Инструкции потока имеют точку входа и выхода


            //System.Threading
            // 1. Thread
            // 2. Semaphone,Mutex , Monitor,InterLock
            // 3. ThreadPool
            // 4. Timer;
            // 5. Delegation (with Thread)
            //


            //Property class Thread
            // -CurrentThread
            // -IsAlive
            // -IsBackground
            // -Name
            // -Priority : Lowerst,BelowNormal,Normal,AboveNormal,Highest
            // -ThreadState:
            //  Unstared,Running,Background,SuspendRequest,
            //  Suspended,AbortRequest,Aborted,WaitSleepJoin,StopRequest,Stoped
            // -ManagedThreadId


            // Method class Thread:
            // -Sleep
            // -Join
            // -Abort
            // -Interrup
            // -Suspend
            // -Start 





            //Thread main = Thread.CurrentThread;
            //Thread.Sleep(1000);
            //main.Interrupt();
            //main.Name = "Main";
            //Console.WriteLine(main.Name);



            //1
            //2
            //3


            //3.sleep(10 * 1000);
            //1.sleep(10 * 1000);
            //2.sleep(10 * 1000);


            //3.join();
            //1.join();
            //2.join();

            //2
            //    Thread myThread = new Thread(new ThreadStart(Count));
            //    myThread.Name = "Second Thread";
            //    myThread.Start();
            //    //1
            //    Thread.CurrentThread.Name = "Main Thread";
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine("Итерация в  потоке #" + Thread.CurrentThread.Name + i);
            //        Thread.Sleep(500);
            //    }

            //    static void Count()
            //    {
            //        for (int i = 0; i < 10; i++)
            //        {
            //            Console.WriteLine("Итерация в  потоке #" + Thread.CurrentThread.Name + i);
            //            Thread.Sleep(1000);
            //        }
            //    }
            //Thread myThread = new Thread(new ParameterizedThreadStart(Count));
            //myThread.Name = "Second Thread";
            //myThread.Start(10);
            ////1
            //Thread.CurrentThread.Name = "Main Thread";
            //Count(10);

            //static void Count(object count)
            //{
            //    int num = (int)count;
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine("Итерация в  потоке #" + Thread.CurrentThread.Name + i);
            //        Thread.Sleep(1000);
            //    }
            //}
            //    Thread thread = new Thread(new ParameterizedThreadStart(TestMethod));
            //    thread.Start(100);

            //    Thread.Sleep(2000);
            //    //thread.Suspend();

            //}
            //static void TestMethod(object obj)
            //{
            //    int count = (int)obj;
            //    for (int i = 0; i < count; i++)
            //    {
            //        Console.WriteLine("Итерация в  потоке #" + i);
            //    }
            //}
            //ulong valueLow = 0;
            //ulong valueBelow = 0;
            //ulong valueNormal = 0;
            //ulong valueAbove = 0;
            //ulong valueHighest = 0;

            //Thread threadLow = new Thread(new ThreadStart(() => { while (true) valueLow++; }));
            //threadLow.Priority = ThreadPriority.Lowest;
            //Thread threadBelow = new Thread(new ThreadStart(() => { while (true) valueBelow++; }));
            //threadBelow.Priority = ThreadPriority.BelowNormal;
            //Thread threadNormal = new Thread(new ThreadStart(() => { while (true) valueNormal++; }));
            //threadNormal.Priority = ThreadPriority.Normal;
            //Thread threadAbove = new Thread(new ThreadStart(() => { while (true) valueAbove++; }));
            //threadAbove.Priority = ThreadPriority.AboveNormal;
            //Thread threadHighest = new Thread(new ThreadStart(() => { while (true) valueHighest++; }));
            //threadHighest.Priority = ThreadPriority.Highest;

            //threadLow.Start();
            //threadBelow.Start();
            //threadNormal.Start();
            //threadAbove.Start();
            //threadHighest.Start();

            //Thread.Sleep(5 * 1000);
            ////threadLow.Abort();
            ////threadBelow.Abort();
            ////threadNormal.Abort();
            ////threadAbove.Abort();
            ////threadHighest.Abort();

            //Console.WriteLine("Lowest       =>  " + valueLow);
            //Console.WriteLine("BelowNormal  =>  " + valueBelow);
            //Console.WriteLine("Normal       =>  " + valueNormal);
            //Console.WriteLine("AboveNormal  =>  " + valueAbove);
            //Console.WriteLine("Highest      =>  " + valueHighest);
            //Thread.Sleep(10 * 1000);

            ThreadPool.SetMinThreads(1, 1);
            ThreadPool.SetMaxThreads(20, 20);
            ThreadPool.GetMinThreads(out int CountThread, out int countCompletionThread);
            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(TestMethod, i);
            }
            Thread.Sleep(1000);
        }
        static void TestMethod(object obj)
        {
            int numberTask = (int)obj;
            int count = 0;
            Console.WriteLine("Thread id: " + Thread.CurrentThread.ManagedThreadId + $" starting work task {numberTask}");
            for (int i = 0; i < 1000000; i++) { count++; }
            Console.WriteLine("Thread id: " + Thread.CurrentThread.ManagedThreadId + $" ended work task {numberTask}");
        }
    }
}
