using FlexCel.XlsAdapter;
using System.Data;

namespace MWShare.ExportHelpers
{
    public class ExportProvider : IExportProvider
    {
        public virtual bool CheckBeforeExport(DataSet dataSet, ExportOptions exportOptions, out string errorMessage)
        {
            errorMessage = string.Empty;
            return true;
        }

        public bool ExportToBase64String(DataSet dataSet, ExportOptions exportOptions, out string errorMessage, out string base64Content)
        {
            errorMessage = string.Empty;
            base64Content = string.Empty;

            bool exportResult = ExportToStream(dataSet, exportOptions, out errorMessage, out MemoryStream outputStream);
            if (exportResult == false) return false;

            outputStream.Seek(0, SeekOrigin.Begin);
            base64Content = Convert.ToBase64String(outputStream.ToArray());

            return true;
        }

        public virtual bool ExportToFile(DataSet dataSet, ExportOptions exportOptions, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrEmpty(exportOptions?.ExportPath))
            {
                errorMessage = "Duong dan file ket xuat khong hop le";
                return false;
            }

            bool exportResult = ExportToStream(dataSet, exportOptions, out errorMessage, out MemoryStream outputStream);
            if (exportResult == false) return false;

            using (var exportFileStream = new FileStream(exportOptions.ExportPath, FileMode.Create))
            {
                outputStream.Seek(0, SeekOrigin.Begin);
                outputStream.CopyTo(exportFileStream);

                exportFileStream.Flush();
            }

            return true;
        }

        public virtual bool ExportToStream(DataSet dataSet, ExportOptions exportOptions, out string errorMessage, out MemoryStream memoryStream)
        {
            errorMessage = "Chua duoc khai bao";
            memoryStream = null;
            return false;
        }

       /* public virtual bool AddLogo(byte[] logo, XlsFile xls)
        {
            xls.AddImage()
        }*/
    }
}
