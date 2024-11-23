using FlexCel.Core;
using FlexCel.Render;
using FlexCel.Report;
using FlexCel.XlsAdapter;
using System.Data;

namespace MWShare.ExportHelpers.ExportExcelHelpers
{
    public class FlexCelUseTemplateExportProvider : ExportProvider
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

            if (string.IsNullOrEmpty(exportOptions.TemplatePath)
                && (exportOptions.TemplateStream == null
                || exportOptions.TemplateStream.Length == 0))
            {
                errorMessage = "Duong dan file mau khong hop le";
                return false;
            }

            if (!string.IsNullOrEmpty(exportOptions.TemplatePath) && File.Exists(exportOptions.TemplatePath) == false)
            {
                errorMessage = "Duong dan file mau khong hop le";
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

            FlexCelReport flcReport = new FlexCelReport();
            flcReport.AddTable(dataSet);
            flcReport.SetValue("Title", exportOptions.Title);
            if (exportOptions.ExportParams?.Count > 0)
            {
                foreach (var key in exportOptions.ExportParams.Keys)
                {
                    flcReport.SetValue(key, exportOptions.ExportParams[key]);
                }
            }

            using var templateStream = !string.IsNullOrEmpty(exportOptions.TemplatePath)
                 ? new FileStream(exportOptions.TemplatePath, FileMode.Open)
                 : exportOptions.TemplateStream;

            templateStream.Seek(0, SeekOrigin.Begin);

            if (exportOptions.ExportType == ExportType.PdfUseExcelTemplate)
            {
                // Export PDF using Flexcel
                using (var xlsStream = new MemoryStream())
                {
                    flcReport.Run(templateStream, xlsStream);
                    xlsStream.Seek(0, SeekOrigin.Begin);

                    using (FlexCelPdfExport flexCelPdfExport = new FlexCelPdfExport(new XlsFile(xlsStream, true)))
                    {
                        FlexCelConfig.GraphicFramework = FlexCelGraphicFramework.SkiaSharp;
                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        flexCelPdfExport.Workbook.AutofitRowsOnWorkbook(false, true, 1);

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
            }
            else
            {
                // Export Xls
                flcReport.Run(templateStream, outputStream);
            }
            outputStream.Seek(0, SeekOrigin.Begin);

            return true;
        }

        public bool ExportToStream(Stream templateStream, DataSet dataSet, ExportOptions exportOptions, out string errorMessage, out MemoryStream outputStream, params Tuple<string, object>[] paramValues)
        {
            errorMessage = string.Empty;
            outputStream = new MemoryStream();

            if (CheckBeforeExport(dataSet, exportOptions, out errorMessage) == false)
                return false;

            FlexCelReport flcReport = new FlexCelReport();
            for (int i = 0; i < paramValues.Count(); i++)
            {
                flcReport.SetValue(paramValues[i].Item1, paramValues[i].Item2);
            }
            flcReport.AddTable(dataSet);


            if (exportOptions.ExportType == ExportType.PdfUseExcelTemplate)
            {
                // Export PDF using Flexcel
                using (var xlsStream = new MemoryStream())
                {
                    flcReport.Run(templateStream, xlsStream);
                    xlsStream.Seek(0, SeekOrigin.Begin);

                    using (FlexCelPdfExport flexCelPdfExport = new FlexCelPdfExport(new XlsFile(xlsStream, true)))
                    {
                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        flexCelPdfExport.Workbook.AutofitRowsOnWorkbook(false, true, 1);

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
            }
            else
            {
                // Export Xls
                flcReport.Run(templateStream, outputStream);
            }
            outputStream.Seek(0, SeekOrigin.Begin);
            templateStream.Dispose();

            return true;
        }
    }
}
