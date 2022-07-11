using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB.SqlSugar.Paged
{
    public class PagedResult<T> where T : class
    {
        public int PageIndex { get; set; } = 1;

        public int PageCount { get; set; }

        public int TotalCount { get; set; } = 0;

        public int PageSize { set; get; }

        public List<T> Data { get; set; }
    }
}
