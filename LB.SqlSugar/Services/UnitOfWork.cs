using LB.SqlSugar.Abstractions;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB.SqlSugar.Services
{
    public class UnitOfWorkL : IUnitOfWork
    {

        public void BeginTransaction()
        {
             GetDbClient().Ado.BeginTran();
        }

        public void Commit()
        {
            try
            {
                GetDbClient().Ado.CommitTran();
            }
            catch (Exception ex)
            {
                Console.WriteLine("roll back");
                this.RollBack();
                throw ex;
            }
        }

        public SqlSugarClient GetDbClient()
        {
            return DbHelper.GetDbInstance();
        }

        public void RollBack()
        {
            GetDbClient().Ado.RollbackTran();
        }
    }
}
