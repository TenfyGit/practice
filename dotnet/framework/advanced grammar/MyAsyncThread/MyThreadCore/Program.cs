using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThreadCore
{
    class Program
    {
        static SemaphoreSlim _sem = new SemaphoreSlim(3);
        static void Main(string[] args)
        {
            {
                for (int i = 1; i < 6; i++)
                {
                    //new Thread(Enter).Start(i);
                    TaskFactory factory = new TaskFactory();
                    factory.StartNew(Enter, i);
                }
            }
            { 
                //线程取消
                CancellationTokenSource cts = new CancellationTokenSource();
                for (int i = 0; i < 40; i++)
                {
                    string name = string.Format("ThreadCore_{0}",i.ToString("00"));
                    Action<object> act = t =>
                        {
                            try
                            {
                                if (t.Equals("ThreadCore_11"))
                                {
                                    throw new Exception(string.Format(""));
                                }
                            }
                            catch (Exception ex)
                            {
                                cts.Cancel();
                                Console.WriteLine(ex.Message);
                            }
                        };
                }
            }
            Console.ReadKey();
        }
        private static void Enter(object id)
        {
            Console.WriteLine("Thread {0} Queue",id);
            _sem.Wait();
            Console.WriteLine("Thread {0} Execute Begin",id);
            Thread.Sleep(1000 * (int)id);
            Console.WriteLine("Thread {0} Execute End",id);
            _sem.Release();
        }
    }
}
