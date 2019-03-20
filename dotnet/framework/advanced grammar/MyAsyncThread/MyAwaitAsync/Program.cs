using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyAwaitAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.WriteLine("Test After ManagedThreadId={0}", Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
        private static async void Test()
        {
            Console.WriteLine("Main Thread Task ManagedThreadId={0}", Thread.CurrentThread.ManagedThreadId);
            await NoReturnTask();

            Console.WriteLine("Main Thread Task ManagedThreadId={0}", Thread.CurrentThread.ManagedThreadId);
            
        }
        private static async Task NoReturnTask()
        { 
            //这里还是主线程的id
            Console.WriteLine("NoReturnTask Sleep before await,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);

            Task task = Task.Run(() =>
             {
                 Console.WriteLine("NoReturnTask Sleep before,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
                 Thread.Sleep(3000);
                 Console.WriteLine("NoReturnTask Sleep after,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
             });
            await task;
            Console.WriteLine("NoReturnTask Sleep after await,ThreadId={0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
