using SqlSugar;
using System;

namespace SqlSugarTest.Mvc.Models
{
    public class CustomSquence
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int Id { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 字段
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// 当前值
        /// </summary>
        public long CurrentValue { get; set; }
        /// <summary>
        /// 增量
        /// </summary>
        public int Inc { get; set; } = 1;
        /// <summary>
        /// 数据库初始化时,序列值是否跟着初始化
        /// </summary>
        public bool IsInit { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string OperateMan { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperateDate { get; set; }
    }
}
