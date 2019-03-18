using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine("****************ThreadPool Start {0} {1}***************", Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            {
                //ThreadPool.QueueUserWorkItem(o =>
                //    {
                //        new Action(() =>
                //        {
                //            Thread.Sleep(2000);
                //            DoSomethingLong("ThreadPool");
                //        }).Invoke();
                //        //如果需要回调,就写在这里
                //        Console.WriteLine("This is Callback");
                //    });
            }
            {
                //ManualResetEvent mre = new ManualResetEvent(false);
                //ThreadPool.QueueUserWorkItem(o =>
                //{
                //    new Action(() =>
                //        {
                //            Thread.Sleep(2000);
                //            DoSomethingLong("ThreadPool");
                //            Console.WriteLine(o.ToString());
                //            mre.Set();
                //        }).Invoke();
                //}, "backbone");
                //Console.WriteLine("Before waitone");
                //mre.WaitOne();
                //Console.WriteLine("After waitone");
            }
            {
                ThreadPool.SetMaxThreads(8, 8);//最小也是核数
                ThreadPool.SetMinThreads(8, 8);
                int workerThreads = 0;
                int ioThreads = 0;
                ThreadPool.GetMaxThreads(out workerThreads, out ioThreads);
                Console.WriteLine(String.Format("Max worker threads: {0};    Max I/O threads: {1}", workerThreads, ioThreads));

                ThreadPool.GetMinThreads(out workerThreads, out ioThreads);
                Console.WriteLine(String.Format("Min worker threads: {0};    Min I/O threads: {1}", workerThreads, ioThreads));

                ThreadPool.GetAvailableThreads(out workerThreads, out ioThreads);
                //Console.WriteLine(String.Format("Available worker threads: {0};    Available I/O threads: {1}", workerThreads, ioThreads));
            }
            watch.Stop();
            Console.WriteLine("****************ThreadPool End   {0} {1}  consume{2}ms***************", Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), watch.ElapsedMilliseconds);
            Console.ReadKey();
        }
        /// <summary>
        /// 一个比较耗时耗资源的私有方法
        /// </summary>
        /// <param name="name"></param>
        private static void DoSomethingLong(string name)
        {
            Console.WriteLine("****************DoSomethingLong Start {0} {1} {2}***************", name,
                Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            long lResult = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                lResult += i;
            }
            //Thread.Sleep(2000);

            Console.WriteLine("****************DoSomethingLong   End {0} {1} {2} {3}***************", name, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), lResult);
        }
    }
}
