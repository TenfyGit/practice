using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine("***Parallel Start {0} {1}***", Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            {
                //Parallel.Invoke(() =>{DoSomethingLong("Parallel_001");},
                //    () =>{DoSomethingLong("Parallel_002");},
                //    () =>{DoSomethingLong("Parallel_003");},
                //    () =>{DoSomethingLong("Parallel_004");},
                //    () =>{DoSomethingLong("Parallel_005");}
                //    );
                //Parallel.For(1, 6, t => { DoSomethingLong("Parallel_00"+t); });
                //Parallel.ForEach(new int[] { 1, 2, 3, 4, 5 }, t => { DoSomethingLong("Parallel_00" + t); });

                ParallelOptions options = new ParallelOptions() { MaxDegreeOfParallelism = 3};
                //Parallel.For(1, 6,options, t => { DoSomethingLong("Parallel_00" + t); });

                Parallel.For(1, 10, options, (t, state) => 
                {
                    DoSomethingLong("Parallel_00" + t);
                    //state.Stop();
                    if (t == 5)
                    {
                        state.Break();
                    }
                });
            }
            watch.Stop();
            Console.WriteLine("***Parallel End   {0} {1}  consume{2}ms***", Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), watch.ElapsedMilliseconds);
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

            Console.WriteLine("***DoSomethingLong   End {0} {1} {2} ***", name, Thread.CurrentThread.ManagedThreadId.ToString("00"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }
    }
}
