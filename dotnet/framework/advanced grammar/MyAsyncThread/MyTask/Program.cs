using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine("***Task Start {0} {1}***", Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            {
                //Task task = Task.Run(() =>
                //    {
                //        Thread.Sleep(2000);
                //        DoSomethingLong("Task");
                //    });
            }
            {
                //TaskFactory taskFactory = Task.Factory;
                //List<Task> taskList = new List<Task>();
                //taskList.Add(taskFactory.StartNew(() => { DoSomethingLong("Task_001"); }));
                //taskList.Add(taskFactory.StartNew(() => { DoSomethingLong("Task_002"); }));
                //taskList.Add(taskFactory.StartNew(() => { DoSomethingLong("Task_003"); }));
                //taskList.Add(taskFactory.StartNew(() => { DoSomethingLong("Task_004"); }));
                //taskList.Add(taskFactory.StartNew(() => { DoSomethingLong("Task_005"); }));

                ////只要任何一个线程完成,就进行回调
                ////taskList.Add(taskFactory.ContinueWhenAny(taskList.ToArray(), t => Console.WriteLine("ContinueWhenAny {0}", Thread.CurrentThread.ManagedThreadId.ToString("00"))));

                ////需要所有的线程执行完成,才会进行回调
                //taskList.Add(taskFactory.ContinueWhenAll(taskList.ToArray(), t => Console.WriteLine("ContinueWhenAll {0}", Thread.CurrentThread.ManagedThreadId.ToString("00"))));

                ////Task.WaitAny(taskList.ToArray());
                ////Console.WriteLine("One Task Finished");

                //Task.WaitAll(taskList.ToArray());
                //Console.WriteLine("All Task Finished");
            }
            { 
                TaskFactory taskFactory = Task.Factory;
                //Task task = taskFactory.StartNew(t => Console.WriteLine("This is Task"), "Data Object")
                //    .ContinueWith(t=>Console.WriteLine("This is Callback of {0}",t.AsyncState));
                Task<int> task = taskFactory.StartNew(() => 123);
                Console.WriteLine("The Task Result is {0}",task.Result);
            }
            watch.Stop();
            Console.WriteLine("***Task End   {0} {1}  consume{2}ms***", Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), watch.ElapsedMilliseconds);
            Console.ReadKey();
        }
        /// <summary>
        /// 一个比较耗时耗资源的私有方法
        /// </summary>
        /// <param name="name"></param>
        private static void DoSomethingLong(string name)
        {
            Console.WriteLine("***DoSomethingLong Start {0} {1} {2}***", name,
                Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            long lResult = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                lResult += i;
            }
            //Thread.Sleep(2000);

            Console.WriteLine("***DoSomethingLong   End {0} {1} {2} {3}***", name, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), lResult);
        }
    }
}
