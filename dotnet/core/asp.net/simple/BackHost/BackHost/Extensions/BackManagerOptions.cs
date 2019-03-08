using System;

namespace BackHost.Extensions
{
    public class BackManagerOptions
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name{get;set;}
        /// <summary>
        ///  获取或者设置检查时间间隔，单位：毫秒，默认 10 秒
        /// </summary>
        public int CheckTime{get;set;} = 10 *1000;
        /// <summary>
        /// 回调委托
        /// </summary>
        public Action CallBack{get;set;}
        /// <summary>
        /// 执行细节传递委托
        /// </summary>
        public Action<BackHandle> Handle{get;set;}
        public void OnHandler(int level,string message,Exception exception = null,object state = null)
        {
            Handle?.Invoke(new BackHandle(){Level = level,Message = message,Exception = exception,State = state});
        }

    }
}
