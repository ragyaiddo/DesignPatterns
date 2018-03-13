using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod.DocumentProcessor
{
    public class XlsDocumentProcessor : BaseDocumentProcessor
    {
        protected override string ExtractData(string filePath)
        {
            return "{docType: .xls}";
        }

        protected override string ParseData(string rawData)
        {
            return rawData;
        }
    }
}
