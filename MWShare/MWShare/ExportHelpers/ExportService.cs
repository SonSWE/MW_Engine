using MWShare.ExportEngine;
using MWShare.ExportHelpers.ExportExcelHelpers;
using System.Data;

namespace MWShare.ExportHelpers
{
    public sealed class ExportService : IExportService
    {
        public bool ExportToBase64String(DataSet dataSet, ExportOptions exportOptions, out string errorMessage, out string base64Content)
        {
            errorMessage = string.Empty;
            base64Content = string.Empty;

            if (!GetExportProvider(exportOptions, out errorMessage, out IExportProvider exportProvider))
                return false;

            return exportProvider.ExportToBase64String(dataSet, exportOptions, out errorMessage, out base64Content);
        }

        public bool ExportToFile(DataSet dataSet, ExportOptions exportOptions, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!GetExportProvider(exportOptions, out errorMessage, out IExportProvider exportProvider))
                return false;

            return exportProvider.ExportToFile(dataSet, exportOptions, out errorMessage);
        }

        public bool ExportToStream(DataSet dataSet, ExportOptions exportOptions, out string errorMessage, out MemoryStream memoryStream)
        {
            errorMessage = string.Empty;
            memoryStream = null;

            if (!GetExportProvider(exportOptions, out errorMessage, out IExportProvider exportProvider))
                return false;

            return exportProvider.ExportToStream(dataSet, exportOptions, out errorMessage, out memoryStream);
        }

        // Private funcs
        private bool GetExportProvider(ExportOptions exportOptions, out string errorMessage, out IExportProvider exportProvider)
        {
            errorMessage = string.Empty;
            exportProvider = null;

            if (exportOptions == null)
            {
                errorMessage = "Cau hinh ket xuat khong hop le";
                return false;
            }

            switch (exportOptions.ExportType)
            {
                case ExportType.None:
                    break;
                case ExportType.Excel:
                    exportProvider = new FlexCelExportProvider();
                    break;
                case ExportType.ExcelUseTemplate:
                    exportProvider = new FlexCelUseTemplateExportProvider();
                    break;
                case ExportType.Pdf:
                    break;
                case ExportType.PdfUseExcel:
                    exportProvider = new FlexCelExportProvider();
                    break;
                case ExportType.PdfUseExcelTemplate:
                    exportProvider = new FlexCelUseTemplateExportProvider();
                    break;
                case ExportType.Word:
                    //exportProvider = new GemboxWordExportProvider();
                    break;
                default:
                    break;
            }

            if (exportProvider == null)
            {
                errorMessage = "Chua ho tro ket xuat dinh dang nay";
                return false;
            }

            return true;
        }
    }
}
