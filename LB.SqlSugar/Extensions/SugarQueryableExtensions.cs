using LB.SqlSugar.Paged;
using SqlSugar;
using SqlSugar.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LB.SqlSugar.Extensions
{
    public static class SugarQueryableExtensions
    {
        public static PagedResult<TEntity> ToPagedResult<TEntity>(
          this ISugarQueryable<TEntity> queryable,
          int pageIndex = 1,
          int pageSize = 20)
          where TEntity : class
        {
            int num1 = 0;
            List<TEntity> pageList = queryable.ToPageList(pageIndex, pageSize, ref num1);
            int num2 = UtilExtensions.ObjToInt((object)Math.Ceiling(UtilExtensions.ObjToDecimal((object)num1) / UtilExtensions.ObjToDecimal((object)pageSize)));
            return new PagedResult<TEntity>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                PageCount = num2,
                TotalCount = num1,
                Data = pageList
            };
        }

        public static PagedResult<TResult> ToPagedResult<T1, T2, TResult>(
          this ISugarQueryable<T1, T2> queryable,
          Expression<Func<T1, T2, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            int num1 = 0;
            List<TResult> pageList = queryable.Select<TResult>(selectExpression).ToPageList(pageIndex, pageSize, ref num1);
            int num2 = UtilExtensions.ObjToInt((object)Math.Ceiling(UtilExtensions.ObjToDecimal((object)num1) / UtilExtensions.ObjToDecimal((object)pageSize)));
            return new PagedResult<TResult>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                PageCount = num2,
                TotalCount = num1,
                Data = pageList
            };
        }

        public static PagedResult<TResult> ToPagedResult<T1, T2, T3, TResult>(
          this ISugarQueryable<T1, T2, T3> queryable,
          Expression<Func<T1, T2, T3, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            int num1 = 0;
            List<TResult> pageList = queryable.Select<TResult>(selectExpression).ToPageList(pageIndex, pageSize, ref num1);
            int num2 = UtilExtensions.ObjToInt((object)Math.Ceiling(UtilExtensions.ObjToDecimal((object)num1) / UtilExtensions.ObjToDecimal((object)pageSize)));
            return new PagedResult<TResult>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                PageCount = num2,
                TotalCount = num1,
                Data = pageList
            };
        }

        public static PagedResult<TResult> ToPagedResult<T1, T2, T3, T4, TResult>(
          this ISugarQueryable<T1, T2, T3, T4> queryable,
          Expression<Func<T1, T2, T3, T4, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            int num1 = 0;
            List<TResult> pageList = queryable.Select<TResult>(selectExpression).ToPageList(pageIndex, pageSize, ref num1);
            int num2 = UtilExtensions.ObjToInt((object)Math.Ceiling(UtilExtensions.ObjToDecimal((object)num1) / UtilExtensions.ObjToDecimal((object)pageSize)));
            return new PagedResult<TResult>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                PageCount = num2,
                TotalCount = num1,
                Data = pageList
            };
        }

        public static PagedResult<TResult> ToPagedResult<T1, T2, T3, T4, T5, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5> queryable,
          Expression<Func<T1, T2, T3, T4, T5, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            int num1 = 0;
            List<TResult> pageList = queryable.Select<TResult>(selectExpression).ToPageList(pageIndex, pageSize, ref num1);
            int num2 = UtilExtensions.ObjToInt((object)Math.Ceiling(UtilExtensions.ObjToDecimal((object)num1) / UtilExtensions.ObjToDecimal((object)pageSize)));
            return new PagedResult<TResult>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                PageCount = num2,
                TotalCount = num1,
                Data = pageList
            };
        }

        public static PagedResult<TResult> ToPagedResult<T1, T2, T3, T4, T5, T6, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5, T6> queryable,
          Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            int num1 = 0;
            List<TResult> pageList = queryable.Select<TResult>(selectExpression).ToPageList(pageIndex, pageSize, ref num1);
            int num2 = UtilExtensions.ObjToInt((object)Math.Ceiling(UtilExtensions.ObjToDecimal((object)num1) / UtilExtensions.ObjToDecimal((object)pageSize)));
            return new PagedResult<TResult>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                PageCount = num2,
                TotalCount = num1,
                Data = pageList
            };
        }

        public static PagedResult<TResult> ToPagedResult<T1, T2, T3, T4, T5, T6, T7, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5, T6, T7> queryable,
          Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            int num1 = 0;
            List<TResult> pageList = queryable.Select<TResult>(selectExpression).ToPageList(pageIndex, pageSize, ref num1);
            int num2 = UtilExtensions.ObjToInt((object)Math.Ceiling(UtilExtensions.ObjToDecimal((object)num1) / UtilExtensions.ObjToDecimal((object)pageSize)));
            return new PagedResult<TResult>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                PageCount = num2,
                TotalCount = num1,
                Data = pageList
            };
        }

        public static PagedResult<TResult> ToPagedResult<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5, T6, T7, T8> queryable,
          Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            int num1 = 0;
            List<TResult> pageList = queryable.Select<TResult>(selectExpression).ToPageList(pageIndex, pageSize, ref num1);
            int num2 = UtilExtensions.ObjToInt((object)Math.Ceiling(UtilExtensions.ObjToDecimal((object)num1) / UtilExtensions.ObjToDecimal((object)pageSize)));
            return new PagedResult<TResult>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                PageCount = num2,
                TotalCount = num1,
                Data = pageList
            };
        }

        public static PagedResult<TResult> ToPagedResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5, T6, T7, T8, T9> queryable,
          Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            int num1 = 0;
            List<TResult> pageList = queryable.Select<TResult>(selectExpression).ToPageList(pageIndex, pageSize, ref num1);
            int num2 = UtilExtensions.ObjToInt((object)Math.Ceiling(UtilExtensions.ObjToDecimal((object)num1) / UtilExtensions.ObjToDecimal((object)pageSize)));
            return new PagedResult<TResult>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                PageCount = num2,
                TotalCount = num1,
                Data = pageList
            };
        }

        public static PagedResult<TResult> ToPagedResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> queryable,
          Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            int num1 = 0;
            List<TResult> pageList = queryable.Select<TResult>(selectExpression).ToPageList(pageIndex, pageSize, ref num1);
            int num2 = UtilExtensions.ObjToInt((object)Math.Ceiling(UtilExtensions.ObjToDecimal((object)num1) / UtilExtensions.ObjToDecimal((object)pageSize)));
            return new PagedResult<TResult>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                PageCount = num2,
                TotalCount = num1,
                Data = pageList
            };
        }

        public static PagedResult<TResult> ToPagedResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> queryable,
          Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            int num1 = 0;
            List<TResult> pageList = queryable.Select<TResult>(selectExpression).ToPageList(pageIndex, pageSize, ref num1);
            int num2 = UtilExtensions.ObjToInt((object)Math.Ceiling(UtilExtensions.ObjToDecimal((object)num1) / UtilExtensions.ObjToDecimal((object)pageSize)));
            return new PagedResult<TResult>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                PageCount = num2,
                TotalCount = num1,
                Data = pageList
            };
        }

        public static PagedResult<TResult> ToPagedResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> queryable,
          Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            int num1 = 0;
            List<TResult> pageList = queryable.Select<TResult>(selectExpression).ToPageList(pageIndex, pageSize, ref num1);
            int num2 = UtilExtensions.ObjToInt((object)Math.Ceiling(UtilExtensions.ObjToDecimal((object)num1) / UtilExtensions.ObjToDecimal((object)pageSize)));
            return new PagedResult<TResult>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                PageCount = num2,
                TotalCount = num1,
                Data = pageList
            };
        }

        private static PagedResult<TResult> GetResult<TResult>(
          List<TResult> page,
          int totalCount,
          int pageIndex,
          int pageSize)
          where TResult : class
        {
            int num = UtilExtensions.ObjToInt((object)Math.Ceiling(UtilExtensions.ObjToDecimal((object)totalCount) / UtilExtensions.ObjToDecimal((object)pageSize)));
            return new PagedResult<TResult>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                PageCount = num,
                TotalCount = totalCount,
                Data = page
            };
        }

        public static async Task<PagedResult<TEntity>> ToPagedResultAsync<TEntity>(
          this ISugarQueryable<TEntity> queryable,
          int pageIndex = 1,
          int pageSize = 20)
          where TEntity : class
        {
            RefAsync<int> totalCount = 0;
            List<TEntity> page = await queryable.ToPageListAsync(pageIndex, pageSize, totalCount);
            PagedResult<TEntity> result = SugarQueryableExtensions.GetResult<TEntity>(page, totalCount, pageIndex, pageSize);
            totalCount = (RefAsync<int>)null;
            page = (List<TEntity>)null;
            return result;
        }

        public static async Task<PagedResult<TResult>> ToPagedResultAsync<T1, T2, TResult>(
          this ISugarQueryable<T1, T2> queryable,
          Expression<Func<T1, T2, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            RefAsync<int> totalCount = 0;
            List<TResult> page = await queryable.Select<TResult>(selectExpression).ToPageListAsync(pageIndex, pageSize, totalCount);
            PagedResult<TResult> result = SugarQueryableExtensions.GetResult<TResult>(page, totalCount, pageIndex, pageSize);
            totalCount = (RefAsync<int>)null;
            page = (List<TResult>)null;
            return result;
        }

        public static async Task<PagedResult<TResult>> ToPagedResultAsync<T1, T2, T3, TResult>(
          this ISugarQueryable<T1, T2, T3> queryable,
          Expression<Func<T1, T2, T3, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            RefAsync<int> totalCount = 0;
            List<TResult> page = await queryable.Select<TResult>(selectExpression).ToPageListAsync(pageIndex, pageSize, totalCount);
            PagedResult<TResult> result = SugarQueryableExtensions.GetResult<TResult>(page, totalCount, pageIndex, pageSize);
            totalCount = (RefAsync<int>)null;
            page = (List<TResult>)null;
            return result;
        }

        public static async Task<PagedResult<TResult>> ToPagedResultAsync<T1, T2, T3, T4, TResult>(
          this ISugarQueryable<T1, T2, T3, T4> queryable,
          Expression<Func<T1, T2, T3, T4, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            RefAsync<int> totalCount = 0;
            List<TResult> page = await queryable.Select<TResult>(selectExpression).ToPageListAsync(pageIndex, pageSize, totalCount);
            PagedResult<TResult> result = SugarQueryableExtensions.GetResult<TResult>(page, totalCount, pageIndex, pageSize);
            totalCount = (RefAsync<int>)null;
            page = (List<TResult>)null;
            return result;
        }

        public static async Task<PagedResult<TResult>> ToPagedResultAsync<T1, T2, T3, T4, T5, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5> queryable,
          Expression<Func<T1, T2, T3, T4, T5, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            RefAsync<int> totalCount = 0;
            List<TResult> page = await queryable.Select<TResult>(selectExpression).ToPageListAsync(pageIndex, pageSize, totalCount);
            PagedResult<TResult> result = SugarQueryableExtensions.GetResult<TResult>(page, totalCount, pageIndex, pageSize);
            totalCount = (RefAsync<int>)null;
            page = (List<TResult>)null;
            return result;
        }

        public static async Task<PagedResult<TResult>> ToPagedResultAsync<T1, T2, T3, T4, T5, T6, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5, T6> queryable,
          Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            RefAsync<int> totalCount = 0;
            List<TResult> page = await queryable.Select<TResult>(selectExpression).ToPageListAsync(pageIndex, pageSize, totalCount);
            PagedResult<TResult> result = SugarQueryableExtensions.GetResult<TResult>(page, totalCount, pageIndex, pageSize);
            totalCount = (RefAsync<int>)null;
            page = (List<TResult>)null;
            return result;
        }

        public static async Task<PagedResult<TResult>> ToPagedResultAsync<T1, T2, T3, T4, T5, T6, T7, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5, T6, T7> queryable,
          Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            RefAsync<int> totalCount = 0;
            List<TResult> page = await queryable.Select<TResult>(selectExpression).ToPageListAsync(pageIndex, pageSize, totalCount);
            PagedResult<TResult> result = SugarQueryableExtensions.GetResult<TResult>(page, totalCount, pageIndex, pageSize);
            totalCount = (RefAsync<int>)null;
            page = (List<TResult>)null;
            return result;
        }

        public static async Task<PagedResult<TResult>> ToPagedResultAsync<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5, T6, T7, T8> queryable,
          Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            RefAsync<int> totalCount = 0;
            List<TResult> page = await queryable.Select<TResult>(selectExpression).ToPageListAsync(pageIndex, pageSize, totalCount);
            PagedResult<TResult> result = SugarQueryableExtensions.GetResult<TResult>(page, totalCount, pageIndex, pageSize);
            totalCount = (RefAsync<int>)null;
            page = (List<TResult>)null;
            return result;
        }

        public static async Task<PagedResult<TResult>> ToPagedResultAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5, T6, T7, T8, T9> queryable,
          Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            RefAsync<int> totalCount = 0;
            List<TResult> page = await queryable.Select<TResult>(selectExpression).ToPageListAsync(pageIndex, pageSize, totalCount);
            PagedResult<TResult> result = SugarQueryableExtensions.GetResult<TResult>(page, totalCount, pageIndex, pageSize);
            totalCount = (RefAsync<int>)null;
            page = (List<TResult>)null;
            return result;
        }

        public static async Task<PagedResult<TResult>> ToPagedResultAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> queryable,
          Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            RefAsync<int> totalCount = 0;
            List<TResult> page = await queryable.Select<TResult>(selectExpression).ToPageListAsync(pageIndex, pageSize, totalCount);
            PagedResult<TResult> result = SugarQueryableExtensions.GetResult<TResult>(page, totalCount, pageIndex, pageSize);
            totalCount = (RefAsync<int>)null;
            page = (List<TResult>)null;
            return result;
        }

        public static async Task<PagedResult<TResult>> ToPagedResultAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> queryable,
          Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            RefAsync<int> totalCount = 0;
            List<TResult> page = await queryable.Select<TResult>(selectExpression).ToPageListAsync(pageIndex, pageSize, totalCount);
            PagedResult<TResult> result = SugarQueryableExtensions.GetResult<TResult>(page, totalCount, pageIndex, pageSize);
            totalCount = (RefAsync<int>)null;
            page = (List<TResult>)null;
            return result;
        }

        public static async Task<PagedResult<TResult>> ToPagedResultAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
          this ISugarQueryable<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> queryable,
          Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>> selectExpression,
          int pageIndex = 1,
          int pageSize = 20)
          where TResult : class
        {
            RefAsync<int> totalCount = 0;
            List<TResult> page = await queryable.Select<TResult>(selectExpression).ToPageListAsync(pageIndex, pageSize, totalCount);
            PagedResult<TResult> result = SugarQueryableExtensions.GetResult<TResult>(page, totalCount, pageIndex, pageSize);
            totalCount = (RefAsync<int>)null;
            page = (List<TResult>)null;
            return result;
        }
    }
}
