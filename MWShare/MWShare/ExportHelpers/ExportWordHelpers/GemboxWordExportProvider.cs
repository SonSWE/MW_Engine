
using GemBox.Document;
using System.Data;
using System.IO;

namespace MWShare.ExportHelpers.ExportWordHelper
{
    public class GemboxWordExportProvider : ExportProvider
    {
        public GemboxWordExportProvider()
        {
            ComponentInfo.SetLicense("DN-2022Aug17-zLmwywdtdsrVh/zk1QhByaDCxyDUYWJKq6FWt9UKeM1pGTsxj1WItU21IgZiy5H1rLkUP9xchSYVXGsK5rsI7iT5WuQ==A");
        }

        public override bool CheckBeforeExport(DataSet dataSet, ExportOptions exportOptions, out string errorMessage)
        {
            return base.CheckBeforeExport(dataSet, exportOptions, out errorMessage);
        }

        public override bool ExportToStream(DataSet dataSet, ExportOptions exportOptions, out string errorMessage, out MemoryStream memoryStream)
        {
            return base.ExportToStream(dataSet, exportOptions, out errorMessage, out memoryStream);
        }
    }
}
