using LB.Execl.Npoi;
using LB.Execl.Npoi.Export;
using LB.Execl.Npoi.Import;
using Microsoft.Extensions.DependencyInjection;
using MS.Cloud.Core.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LB.Execl.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExecl(this IServiceCollection services)
        {
            services.AddSingleton<INpoiCellStyleHandle, NpoiCellStyleHandle>();
            services.AddSingleton<INpoiExcelHandle, NpoiExcelHandle>();

            services.AddTransient<IExcelImportManager, NpoiExcelImportProvider>();
            services.AddTransient<IExcelExportManager, NpoiExcelExportProvider>();

            return services;
        }

        public static IServiceCollection AddExecl(
         this IMsCloudBuilder builder)
        {
            return builder.Services.AddExecl();
        }
    }
}
