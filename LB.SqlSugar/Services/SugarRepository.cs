using LB.SqlSugar.Abstractions;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB.SqlSugar.Services 
{
    public class SugarRepository<TEntity> :
    SimpleClient<TEntity>,
    ISugarRepository<TEntity>,
    ISimpleClient<TEntity>
    where TEntity : class, new()
    {
        public SugarRepository(ISqlSugarClient context = null) : base(context)
        {

            // base.Context = context;//ioc注入的对象
            // base.Context=DbScoped.SugarScope; SqlSugar.Ioc这样写
            // base.Context=DbHelper.GetDbInstance()当然也可以手动去赋值
            base.Context = DbHelper.GetDbInstance();
        }
    }
}
