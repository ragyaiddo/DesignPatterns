using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Autofac.Features.Indexed;
using TemplateMethod.DocumentProcessor;

namespace TemplateMethod
{
    public class DocumentProcessorClient: IDocumentProcessorClient
    {
        private readonly IIndex<FileTypeEnum, IDocumentProcessor> _documentProcessorFactory;

        public DocumentProcessorClient(IIndex<FileTypeEnum,IDocumentProcessor> documentProcessorFactoryFactoryIndex)
        {
            _documentProcessorFactory = documentProcessorFactoryFactoryIndex;
        }

        public string ProcessFile(DocumentInfo documentInfo)
        {
            IDocumentProcessor processor;
            if (_documentProcessorFactory.TryGetValue(documentInfo.FileType, out processor))
            {
               return processor.Execute(documentInfo.FilePath);
            }
            else
            {
                throw new NotSupportedException($"Unsupported document type '{documentInfo.FileType}'");
            }
        }
    }
}
