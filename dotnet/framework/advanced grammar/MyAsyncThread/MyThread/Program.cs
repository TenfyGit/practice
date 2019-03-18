using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThread
{
    class Program
    {
        public delegate void DoSomething(string name);
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();

            Console.ReadKey();
        }
        private void Start()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine("****************Thread Start {0} {1}***************", Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            ThreadStart threadStart = new ThreadStart(() =>
            {
                Thread.Sleep(3000);
                this.DoSomethingLong("Thread_Start");
            });
            Thread thread = new Thread(threadStart);
            //thread.IsBackground = true;
            //thread.Start();
            //while (thread.IsAlive)
            //{
            //    Thread.Sleep(500);
            //    Console.WriteLine("System is running");
            //}
            //this.ThreadWithCallback(() =>
            //    {
            //        Thread.Sleep(2000);
            //        Console.WriteLine("This is ThreadStart {0}",Thread.CurrentThread.ManagedThreadId.ToString("00"));
            //    }, () =>
            //    {
            //        Thread.Sleep(2000);
            //        Console.WriteLine("This is Callback {0}",Thread.CurrentThread.ManagedThreadId.ToString("00"));
            //    });
            Func<int> func = this.ThreadWithReturn(() =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("This is ThreadStart {0}",Thread.CurrentThread.ManagedThreadId.ToString("00"));
                    return 123456;
                });
            Console.WriteLine("Already Implemented here");
            int result = func.Invoke();
            Console.WriteLine("The ThreadWithReturn Result is {0}",result);
            watch.Stop();
            Console.WriteLine("****************Thread_End   {0} {1}  consume{2}ms***************",Thread.CurrentThread.ManagedThreadId.ToString("00"),DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),watch.ElapsedMilliseconds);
        }
        /// <summary>
        /// 基于Thread封装支持回调
        /// </summary>
        /// <param name="threadStart">執行程序</param>
        /// <param name="callback">回調</param>
        private void ThreadWithCallback(ThreadStart threadStart, Action callback)
        {
            ThreadStart threadNew = new ThreadStart(() =>
            {
                threadStart.Invoke();
                callback.Invoke();
            });
            Thread thread = new Thread(threadNew);
            thread.Start();
        }
        /// <summary>
        /// 基于Thread封装支持返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcT"></param>
        /// <returns></returns>
        private Func<T> ThreadWithReturn<T>(Func<T> funcT)
        {
            T t = default(T);
            ThreadStart threadStart = new ThreadStart(() =>
            {
                t = funcT.Invoke();
            });
            Thread thread = new Thread(threadStart);
            thread.Start();
            return new Func<T>(() =>
                {
                    thread.Join();
                    return t;
                });
        }
        /// <summary>
        /// 一个比较耗时耗资源的私有方法
        /// </summary>
        /// <param name="name"></param>
        private void DoSomethingLong(string name)
        {
            Console.WriteLine("****************DoSomethingLong Start {0} {1} {2}***************",name,
                Thread.CurrentThread.ManagedThreadId.ToString("00"),DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
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
