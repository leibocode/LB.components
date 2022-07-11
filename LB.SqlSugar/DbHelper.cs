using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB.SqlSugar
{
    public class DbHelper
    {
        private static readonly string ConnectionString = ConfigurationManager.AppSettings["sugarDB"];
        private static readonly bool isLog = ConfigurationManager.AppSettings["sugarDBLog"]==null?true: bool.Parse(ConfigurationManager.AppSettings["sugarDBLog"]);
        private static readonly int DbType = ConfigurationManager.AppSettings["sugarDbType"] == null ? 1 : int.Parse(ConfigurationManager.AppSettings["sugarDBLog"]);
        public static SqlSugarClient GetDbInstance()
        {
            try
            {
                var db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = ConnectionString,
                    DbType = (DbType)DbType,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                });

                if (isLog)
                {
                    db.Aop.OnLogExecuted = ((sql, paras) =>
                    {
                        Console.WriteLine(string.Format("【执行SQL：{0}】【执行时间：{1}】", (object)sql, (object)db.Ado.SqlExecutionTime));
                        Console.WriteLine("【SQL参数" + Newtonsoft.Json.JsonConvert.SerializeObject((paras.ToDictionary(p => p.ParameterName, p => p.Value)) + "】"));

                    });
                }

                return db;
            }
            catch (Exception ex)
            {
                throw new Exception("连接数据库出错，请检查您的连接字符串和网络。 ex:" + ex.Message);
            }
        }
    }
}
