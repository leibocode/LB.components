using LB.Execl.Attributes;
using NPOI.SS.UserModel;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LB.API.Models
{
    [RowHeight(20,30)]
    public class ExportTestClasss
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        public virtual string Name { get; set; }

        /// <summary>
        /// 姓名1
        /// </summary>
        [Display(Name = "姓名1")]
        //[HeaderStyle(ColumnSize = 40)]
        //[DataFont(FontHeightInPoints = 15)]
        public virtual string Name1 { get; set; }

        /// <summary>
        /// 姓名2
        /// </summary>
        [Display(Name = "姓名11")]
        //[DataFont(FontHeightInPoints = 18)]
        public virtual string Name11 { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [Display(Name = "日期")]
        [DataStyle(DataFormat = "yyyy\"年\"m\"月\"d\"日\";@")]
        //[ColumnStats((int)FunctionEnum.Avg)]
        public virtual DateTime? Date { get; set; }

        /// <summary>
        /// 日期2
        /// </summary>
        [Display(Name = "日期2")]
        [DefaultValue(typeof(DateTime), "2020-9-9")]
        public virtual DateTime? Date1 { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Display(Name = "年龄")]
        [ColumnStats((int)FunctionEnum.Sum,Label ="合计")]
        public virtual int Age { get; set; }

        /// <summary>
        /// 成绩
        /// </summary>
        [Display(Name = "成绩")]
        public virtual decimal? Score { get; set; }

        [Display( Name= "微信openid")]
        public virtual string WxNmae { get; set; }
       
    }
}
