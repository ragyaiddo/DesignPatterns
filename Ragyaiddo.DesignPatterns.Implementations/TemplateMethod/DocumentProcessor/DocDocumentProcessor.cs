using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod.DocumentProcessor
{
    public class DocDocumentProcessor : BaseDocumentProcessor
    {
       protected override string ExtractData(string filePath)
        {
            return "{docType: .doc}";
        }
    }
}
