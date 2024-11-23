using MWShare.ExportHelpers;
using System.Data;

namespace MWShare.ExportEngine
{
    public interface IExportService
    {
        bool ExportToBase64String(DataSet dataSet, ExportOptions exportOptions, out string errorMessage, out string base64Content);
        bool ExportToFile(DataSet dataSet, ExportOptions exportOptions, out string errorMessage);
        bool ExportToStream(DataSet dataSet, ExportOptions exportOptions, out string errorMessage, out MemoryStream memoryStream);
    }
}
