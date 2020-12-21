using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using SqlSugarTest.Mvc.Models;

namespace SqlSugarTest.Mvc.Controllers
{
    public class CustomSquenceController : Controller
    {
        public ActionResult<IEnumerable<string>> Index()
        {
            GetCustomSquenceList();
            return new string[] { "123"};
        }
        //查询所有
        public List<CustomSquence> GetCustomSquenceList()
        {
            var db = GetInstance();//获取SqlSugarClient 
            var list = db.Queryable<CustomSquence>().ToList();//查询表的所有
            return list;
        }

        //创建SqlSugarClient 
        private SqlSugarClient GetInstance()
        {
            //创建数据库对象
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=192.168.23.228;user id=mylife;password=mylife;database=mylims;charset=utf8;sslMode=None",//连接符字串
                DbType = DbType.MySql,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute//从特性读取主键自增信息
            });

            //添加Sql打印事件，开发中可以删掉这个代码
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;
        }
    }
}
