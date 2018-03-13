using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod
{
    public interface IDocumentProcessorClient
    {
        string ProcessFile(DocumentInfo documentInfo);
    }
}
