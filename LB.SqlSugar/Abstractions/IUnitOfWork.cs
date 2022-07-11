using LB.SqlSugar.Options;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB.SqlSugar.Abstractions
{
    public interface IUnitOfWork
    {
        SqlSugarClient GetDbClient();

        void BeginTransaction();

        void Commit();

        void RollBack();
    }
}
