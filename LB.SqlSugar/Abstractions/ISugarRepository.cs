using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB.SqlSugar.Abstractions
{
    public interface ISugarRepository<TEntity> : ISimpleClient<TEntity> where TEntity : class, new()
    {

    }
}
