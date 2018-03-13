using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod.DocumentProcessor
{
    public class PdfDocumentProcessor : BaseDocumentProcessor
    {
        protected override string ExtractData(string filePath)
        {
            return "{docType: .pdf}";
        }
    }
}
