using System;

namespace BackHost.Extensions
{
    public class BackHandle
    {
        /// <summary>
        /// 0=Info，1=Debug，2=Error
        /// </summary>
        public int Level{get;set;}
        public string Message{get;set;}
        public Exception Exception{get;set;}
        public object State{get;set;}
    }
}
