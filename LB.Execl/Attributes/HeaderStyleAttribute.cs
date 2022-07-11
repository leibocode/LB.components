﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;

namespace LB.Execl.Attributes
{
    /// <summary>
    /// Excel表头特性（导出时用）
    /// <para>1.应用在类、字段、属性上，仅对表头有效</para>
    /// <para>2.若类和属性上都存在，则属性上的有效，类上的无效</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class HeaderStyleAttribute : Attribute
    {
        /// <summary>
        /// 自适应宽度
        /// <para>Npoi</para>
        /// <para>EpPlus</para>
        /// </summary>
        public bool ShrinkToFit { get; set; }

        /// <summary>
        /// 列自动调整大小，默认 false
        /// <para>若 <see cref="ColumnSize"/> > 0 ，则 <see cref="ColumnSize"/> 有效</para>
        /// <para>Npoi</para>
        /// <para>EpPlus</para>
        /// </summary>
        public bool ColumnAutoSize { get; set; }

        /// <summary>
        /// 列宽
        /// <para>单位：字符</para>
        /// <para>取值区间： [0-255]</para>
        /// <para>Npoi</para>
        /// <para>EpPlus</para>
        /// </summary>
        [Range(0, 255)]
        public int ColumnSize { get; set; } = -1;

        /// <summary>
        /// 数据格式
        /// <para>Npoi</para>
        /// <para>EpPlus</para>
        /// </summary>
        public string DataFormat { get; set; }

        /// <summary>
        /// 是否自动换行
        /// <para>Npoi</para>
        /// <para>EpPlus</para>
        /// </summary>
        public bool WrapText { get; set; }

        /// <summary>
        /// 缩进
        /// <para>Npoi</para>
        /// <para>EpPlus</para>
        /// </summary>
        public short Indention { get; set; } = -1;

        /// <summary>
        /// 水平对齐方式
        /// <para>NPOI：<see cref="NPOI.SS.UserModel.HorizontalAlignment"/></para>
        /// <para>EpPlus：<see cref="ExcelHorizontalAlignment"/></para>
        /// </summary>
        public short Alignment { get; set; }

        /// <summary>
        /// 垂直对齐方式
        /// <para>NPOI：<see cref="NPOI.SS.UserModel.VerticalAlignment"/></para>
        /// <para>EpPlus：<see cref="ExcelVerticalAlignment"/></para>
        /// </summary>
        public short VerticalAlignment { get; set; }

        /// <summary>
        /// 是否隐藏
        /// <para>Npoi</para>
        /// <para>EpPlus</para>
        /// </summary>
        public bool IsHidden { get; set; }

        /// <summary>
        /// 是否锁定
        /// <para>Npoi</para>
        /// <para>EpPlus</para>
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// 旋转
        /// <para>Npoi</para>
        /// <para>EpPlus</para>
        /// </summary>
        public short Rotation { get; set; } = -1;

        /// <summary>
        /// 左边框
        /// <para>NPOI：<see cref="BorderStyle"/></para>
        /// <para>EpLus：<see cref="ExcelBorderStyle"/></para>
        /// </summary>
        public short BorderLeft { get; set; } = -1;

        /// <summary>
        /// 右边框
        /// <para>NPOI：<see cref="BorderStyle"/></para>
        /// <para>EpLus：<see cref="ExcelBorderStyle"/></para>
        /// </summary>
        public short BorderRight { get; set; } = -1;

        /// <summary>
        /// 上边框
        /// <para>NPOI：<see cref="BorderStyle"/></para>
        /// <para>EpLus：<see cref="ExcelBorderStyle"/></para>
        /// </summary>
        public short BorderTop { get; set; } = -1;

        /// <summary>
        /// 下边框
        /// <para>NPOI：<see cref="BorderStyle"/></para>
        /// <para>EpLus：<see cref="ExcelBorderStyle"/></para>
        /// </summary>
        public short BorderBottom { get; set; } = -1;

        /// <summary>
        /// 左边框颜色
        /// <para>NPOI：<see cref="IndexedColors"/> <see cref="HSSFColor"/>，如：HSSFColor.Black.Index,IndexedColors.Black.Index</para>
        /// <para>EpPlus：<see cref="System.Drawing.Color"/></para>
        /// </summary>
        public short LeftBorderColor { get; set; } = -1;

        /// <summary>
        /// 右边框颜色
        /// <para>NPOI：<see cref="IndexedColors"/> <see cref="HSSFColor"/>，如：HSSFColor.Black.Index,IndexedColors.Black.Index</para>
        /// <para>EpPlus：<see cref="System.Drawing.Color"/></para>
        /// </summary>
        public short RightBorderColor { get; set; } = -1;

        /// <summary>
        /// 上边框颜色
        /// <para>NPOI：<see cref="IndexedColors"/> <see cref="HSSFColor"/>，如：HSSFColor.Black.Index,IndexedColors.Black.Index</para>
        /// <para>EpPlus：<see cref="System.Drawing.Color"/></para>
        /// </summary>
        public short TopBorderColor { get; set; } = -1;

        /// <summary>
        /// 下边框颜色
        /// <para>NPOI：<see cref="IndexedColors"/> <see cref="HSSFColor"/>，如：HSSFColor.Black.Index,IndexedColors.Black.Index</para>
        /// <para>EpPlus：<see cref="System.Drawing.Color"/></para>
        /// </summary>
        public short BottomBorderColor { get; set; } = -1;
        /// <summary>
        /// 填充图案
        /// <para>NPOI：<see cref="NPOI.SS.UserModel.FillPattern"/></para>
        /// <para>EpPlus：<see cref="ExcelFillStyle"/></para>
        /// </summary>
        public short FillPattern { get; set; } = -1;

        /// <summary>
        /// 填充背景色
        /// <para>NPOI：<see cref="IndexedColors"/> <see cref="HSSFColor"/>，如：HSSFColor.Black.Index,IndexedColors.Black.Index</para>
        /// <para>EpPlus：<see cref="System.Drawing.Color"/></para>
        /// </summary>
        public short FillBackgroundColor { get; set; } = -1;

        /// <summary>
        /// 填充前景颜色
        /// <para>NPOI：<see cref="IndexedColors"/> <see cref="HSSFColor"/>，如：HSSFColor.Black.Index,IndexedColors.Black.Index</para>
        /// </summary>
        public short FillForegroundColor { get; set; } = -1;

        /// <summary>
        /// 边框对角线颜色
        /// <para>NPOI：<see cref="IndexedColors"/> <see cref="HSSFColor"/>，如：HSSFColor.Black.Index,IndexedColors.Black.Index</para>
        /// <para>EpPlus：<see cref="System.Drawing.Color"/></para>
        /// </summary>
        public short BorderDiagonalColor { get; set; } = -1;

        /// <summary>
        /// 边框对角线样式
        /// <para>NPOI：<see cref="BorderStyle"/></para>
        /// <para>EpPlus：<see cref="ExcelBorderStyle"/></para>
        /// </summary>
        public short BorderDiagonalLineStyle { get; set; } = -1;

        /// <summary>
        /// 边框对角线
        /// <para>NPOI：<see cref="NPOI.SS.UserModel.BorderDiagonal"/></para>
        /// </summary>
        public int BorderDiagonal { get; set; } = -1;

        /// <summary>
        /// 构造
        /// </summary>
        public HeaderStyleAttribute()
        {
            IsLocked = true;
            Alignment = 2;
            VerticalAlignment = 1;
        }
    }
}
