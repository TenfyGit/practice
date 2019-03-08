using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace BackHost.Extensions
{
    public class BackManagerService : BackgroundService
    {
        BackManagerOptions backManagerOptions = new BackManagerOptions();
        public BackManagerService(Action<BackManagerOptions> options)
        {
            options.Invoke(backManagerOptions);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //延迟启动
            await Task.Delay(this.backManagerOptions.CheckTime,stoppingToken);
            backManagerOptions.OnHandler(0,$"正在启动托管服务 {this.backManagerOptions.Name}...");
            stoppingToken.Register(() =>
            {
                backManagerOptions.OnHandler(1,$"托管服务 {this.backManagerOptions.Name} 已经停止");
            });
            int count = 0;
            while(!stoppingToken.IsCancellationRequested)
            {
                count++;
                backManagerOptions.OnHandler(1,$"{this.backManagerOptions.Name} 第 {count} 次执行任务 .....");
                try
                {
                    
                }
            }
        }
    }
}
