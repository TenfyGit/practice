using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyQuartz.JobExecute.Extensions
{
    /// <summary>
    /// 监控Job
    /// 监控Job进程的工具情况，主要定时向存储器更新时间戳
    /// </summary>
    public class MonitorJob : JobBase
    {
        protected override void ExcuteJob(IJobExecutionContext context)
        {
            string msg = "Monitor Job is Excuted "+DateTime.Now;
            base.Logger.Info(msg);
        }
    }
    
}