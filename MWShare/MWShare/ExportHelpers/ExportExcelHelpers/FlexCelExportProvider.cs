using FlexCel.Core;
using FlexCel.Render;
using FlexCel.XlsAdapter;
using System.Data;
using System.Linq;
using SkiaSharp;
namespace MWShare.ExportHelpers.ExportExcelHelpers
{
    public class FlexCelExportProvider : ExportProvider
    {
        public override bool CheckBeforeExport(DataSet dataSet, ExportOptions exportOptions, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (dataSet == null || dataSet.Tables.Count == 0)
            {
                errorMessage = "Khong co du lieu ket xuat";
                return false;
            }

            if (exportOptions == null)
            {
                errorMessage = "Cau hinh ket xuat khong hop le";
                return false;
            }

            return true;
        }

        public override bool ExportToStream(DataSet dataSet, ExportOptions exportOptions, out string errorMessage, out MemoryStream outputStream)
        {
            errorMessage = string.Empty;
            outputStream = new MemoryStream();

            if (CheckBeforeExport(dataSet, exportOptions, out errorMessage) == false)
                return false;

            List<DataColumn> srcTableColumns = new();
            for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
            {
                srcTableColumns.Add(dataSet.Tables[0].Columns[i]);
            }

            List<string> columnNames = new List<string>();
            if (exportOptions.KeepDataSourceColumn)
            {
                foreach (DataColumn dc in srcTableColumns)
                {
                    columnNames.Add(dc.ColumnName);
                }
            }
            else
            {
                columnNames = exportOptions.ExportColDefs.Keys.ToList();
            }

            //
            XlsFile xls = new XlsFile(1, TExcelFileFormat.v2019, true);
            xls.SetFont(0, new TFlxFont() { Name = "Arial" });

            // Cell A2: Header report
            TFlxFormat headerFormat = xls.GetDefaultFormat;
            headerFormat.HAlignment = THFlxAlignment.left;
            headerFormat.VAlignment = TVFlxAlignment.center;
            headerFormat.Font.Style = TFlxFontStyles.Bold;
            int headerFormatXF = xls.AddFormat(headerFormat);

            xls.SetCellValue(2, 1, exportOptions.Title);
            xls.SetCellFormat(2, 1, headerFormatXF);

            // Row 4: Table header
            TFlxFormat tableHeaderFormat = xls.GetDefaultFormat;
            tableHeaderFormat.HAlignment = THFlxAlignment.center;
            tableHeaderFormat.VAlignment = TVFlxAlignment.center;
            tableHeaderFormat.Font.Style = TFlxFontStyles.Bold;
            tableHeaderFormat.WrapText = true;
            tableHeaderFormat.Borders.SetAllBorders(TFlxBorderStyle.Thin, TExcelColor.FromArgb(75, 75, 75));
            tableHeaderFormat.FillPattern.Pattern = TFlxPatternStyle.Solid;
            tableHeaderFormat.FillPattern.BgColor = TExcelColor.FromArgb(224, 224, 224);
            int tableHeaderFormatXF = xls.AddFormat(tableHeaderFormat);

            for (int i = 0; i < columnNames.Count; i++)
            {
                string columnName = columnNames[i];

                xls.SetCellValue(4, i + 1, columnName);
                xls.SetCellFormat(4, i + 1, tableHeaderFormatXF);
                xls.SetColWidth(i + 1, 15 * 256);

                if (exportOptions.ExportColDefs?.ContainsKey(columnName) == true)
                {
                    var colDef = exportOptions.ExportColDefs[columnName];
                    if (!string.IsNullOrEmpty(colDef.ColumnDesc))
                    {
                        xls.SetCellValue(4, i + 1, colDef.ColumnDesc);
                    }

                    if (colDef.Width > 0)
                    {
                        xls.SetColWidth(i + 1, colDef.Width * 256);
                    }

                    if (!string.Equals(colDef.Display, "Y"))
                    {
                        xls.SetColHidden(i + 1, true);
                    }
                }
            }

            // From row 5: Insert table data
            Dictionary<string, int> dicCellFormatXFByColumnName = new Dictionary<string, int>();
            int startRowNum = 5;
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                for (int cIdx = 0; cIdx < columnNames.Count; cIdx++)
                {
                    string columnName = columnNames[cIdx];
                    TypeCode colTypeCode = TypeCode.String;
                    object value = null;

                    var dataColumn = srcTableColumns.FirstOrDefault(c => string.Equals(c.ColumnName, columnName, StringComparison.OrdinalIgnoreCase));
                    if (dataColumn != null)
                    {
                        colTypeCode = Type.GetTypeCode(dataColumn.DataType);
                        value = dr[dataColumn.ColumnName];
                    }

                    // Get or Create cell format
                    if (dicCellFormatXFByColumnName.ContainsKey(columnName) == false)
                    {
                        TFlxFormat cellFormat = xls.GetDefaultFormat;

                        cellFormat.WrapText = true;
                        cellFormat.VAlignment = TVFlxAlignment.top;
                        cellFormat.Borders.SetAllBorders(TFlxBorderStyle.Thin, TExcelColor.FromArgb(75, 75, 75));

                        SetStyleCellRangeByDataType(ref cellFormat, colTypeCode);
                        FormatCellRangeByColDef(ref cellFormat, columnName, exportOptions.ExportColDefs);

                        int cellFormatXF = xls.AddFormat(cellFormat);
                        dicCellFormatXFByColumnName[columnName] = cellFormatXF;
                    }

                    if (value == null || value == DBNull.Value || (colTypeCode == TypeCode.DateTime && (DateTime)value == DateTime.MinValue))
                    {
                        //
                    }
                    else
                    {
                        xls.SetCellValue(startRowNum, cIdx + 1, value);
                    }
                    xls.SetCellFormat(startRowNum, cIdx + 1, dicCellFormatXFByColumnName[columnName]);
                }
                //
                startRowNum++;
            }

            // 
            if (exportOptions.ExportType == ExportType.PdfUseExcel)
            {
                //for (int i = columnNames.Count; i > 0; i--)
                //{
                //    if (exportOptions.ExportColDefs?.ContainsKey(columnNames[i - 1]) == true)
                //    {
                //        var colDef = exportOptions.ExportColDefs[columnNames[i - 1]];
                //        if (!string.Equals(colDef.Display, "Y"))
                //        {
                //            xls.DeleteRange(new TXlsCellRange(1, i, FlxConsts.Max_Rows + 1, i), TFlxInsertMode.ShiftRangeRight);
                //        }
                //    }
                //}

                using (FlexCelPdfExport flexCelPdfExport = new FlexCelPdfExport(xls))
                {
                    FlexCel.Core.FlexCelConfig.GraphicFramework = FlexCelGraphicFramework.SkiaSharp;
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    //flexCelPdfExport.Workbook.AutofitRowsOnWorkbook(false, true, 1);

                    #region Fit width page

                    flexCelPdfExport.Workbook.PrintPaperSize = TPaperSize.A4Rotated;
                    flexCelPdfExport.Workbook.PrintToFit = true;
                    flexCelPdfExport.Workbook.PrintNumberOfHorizontalPages = 1;
                    flexCelPdfExport.Workbook.PrintNumberOfVerticalPages = ushort.MaxValue;

                    #endregion

                    flexCelPdfExport.BeginExport(outputStream);
                    flexCelPdfExport.ExportAllVisibleSheets(false, "");
                    flexCelPdfExport.EndExport();
                }
            }
            else
            {
                xls.Save(outputStream, TFileFormats.Xlsx);
            }
            return true;
        }

        // Private funcs
        #region Private funcs

        private void SetStyleCellRangeByDataType(ref TFlxFormat format, TypeCode typeCode)
        {
            switch (typeCode)
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    format.HAlignment = THFlxAlignment.right;
                    break;
                case TypeCode.DateTime:
                    format.HAlignment = THFlxAlignment.center;
                    break;
                default:
                    break;
            }
        }

        private void FormatCellRangeByColDef(ref TFlxFormat format, string columnName, Dictionary<string, ExportColumnDef> exportColDefs)
        {
            if (exportColDefs == null || string.IsNullOrEmpty(columnName)) return;

            if (exportColDefs.ContainsKey(columnName) == false) return;

            var colDef = exportColDefs[columnName];
            if (colDef == null) return;

            if (!string.IsNullOrEmpty(colDef.Format))
                format.Format = colDef.Format;

            if (!string.IsNullOrEmpty(colDef.Align))
            {
                switch (colDef.Align)
                {
                    case "C":
                        format.HAlignment = THFlxAlignment.center;
                        break;
                    case "R":
                        format.HAlignment = THFlxAlignment.right;
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}
