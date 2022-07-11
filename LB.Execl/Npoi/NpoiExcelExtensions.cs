using Microsoft.Extensions.DependencyInjection;
using LB.Execl.Npoi.Import;
using LB.Execl.Npoi.Export;

namespace LB.Execl.Npoi
{
    public static class NpoiExcelExtensions
    {
        /// <summary>
        /// 使用 NPOI excel导入导出
        /// </summary>
        /// <param name="services"></param>
        public static void AddNpoiExcel(this IServiceCollection services)
        {
            services.AddSingleton<INpoiCellStyleHandle, NpoiCellStyleHandle>();
            services.AddSingleton<INpoiExcelHandle, NpoiExcelHandle>();

            services.AddTransient<IExcelImportManager, NpoiExcelImportProvider>();
            services.AddTransient<IExcelExportManager, NpoiExcelExportProvider>();
        }
    }
}
