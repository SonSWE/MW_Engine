using System.Data;

namespace MWShare.ExportHelpers
{
    public interface IExportProvider
    {
        bool ExportToBase64String(DataSet dataSet, ExportOptions exportOptions, out string errorMessage, out string base64Content);
        bool ExportToFile(DataSet dataSet, ExportOptions exportOptions, out string errorMessage);
        bool ExportToStream(DataSet dataSet, ExportOptions exportOptions, out string errorMessage, out MemoryStream memoryStream);
        bool CheckBeforeExport(DataSet dataSet, ExportOptions exportOptions, out string errorMessage);
    }
}
