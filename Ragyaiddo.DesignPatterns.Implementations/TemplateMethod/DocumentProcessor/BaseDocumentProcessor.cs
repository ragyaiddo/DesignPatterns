using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethod.DocumentProcessor
{
    public abstract class BaseDocumentProcessor : IDocumentProcessor
    {
        public string Execute(string filePath)
        {
            string rawData = ExtractData(filePath);
            string parsedData = ParseData(rawData);

            if (!ValidateData(parsedData))
            {
                //handle error
            }

            return parsedData;
        }

        protected bool ValidateData(string parsedData)
        {
            return !string.IsNullOrWhiteSpace(parsedData);
        }

        protected virtual string ParseData(string rawData)
        {
            return rawData;
        }

        protected abstract string ExtractData(string filePath);

    }
}
