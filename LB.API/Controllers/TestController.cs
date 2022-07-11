
using Microsoft.AspNetCore.Mvc;
using LB.Execl;
using System.Threading.Tasks;
using MS.Cloud.AspNetCore.Models;
using LB.API.Models;
using System.Collections.Generic;
using System.IO;

namespace LB.API.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        public readonly IExcelExportManager _excelExportManager;

        public TestController(IExcelExportManager excelExportManager)
        {
            _excelExportManager = excelExportManager;
        }

        [HttpGet]
        public async Task<IActionResult> ExportExecl()
        {
            var list = new List<ExportTestClasss>()
            {
                new ExportTestClasss
                {
                    Name = "name",
                    Age = 18,
                    Name1 = "mame1",
                    Name11 = "sss",
                    Date = System.DateTime.Now,
                    WxNmae = "openid"
                },
                new ExportTestClasss
                {
                    Name = "name",
                    Age = 18,
                    Name1 = "mame1",
                    Name11 = "sss",
                    Date = System.DateTime.Now,
                    WxNmae = "openid"
                },
                new ExportTestClasss
                {
                    Name = "name",
                    Age = 18,
                    Name1 = "mame1",
                    Name11 = "sss",
                    Date = System.DateTime.Now,
                    WxNmae = "openid"
                },new ExportTestClasss
                {
                    Name = "name",
                    Age = 18,
                    Name1 = "mame1",
                    Name11 = "sss",
                    Date = System.DateTime.Now,
                    WxNmae = "openid"
                }
                ,new ExportTestClasss
                {
                    Name = "name",
                    Age = 18,
                    Name1 = "mame1",
                    Name11 = "sss",
                    Date = System.DateTime.Now,
                    WxNmae = "openid"
                }
            };

            var bytes = await _excelExportManager.ExportAsync(list, options =>
            {
                options.ExcelType = Execl.Models.ExcelTypeEnum.Xlsx;
            });

            using (var stream = new MemoryStream(bytes))
            {
                return new FileContentResult(stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "test.xlsx"
                };
            }
        }
    }
}
