using System;
using System.IO;
using System.Runtime.CompilerServices;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using TemplateMethod.DocumentProcessor;

namespace TemplateMethod
{
    class Program
    {
        // public IContainer ApplicationContainer { get; private set; }

        static void Main(string[] args)
        {
           var serviceProvider = new ServiceCollection();

            var builder = new ContainerBuilder();

            builder.RegisterType<DocumentProcessorClient>().As<IDocumentProcessorClient>();

            builder.RegisterType<DocDocumentProcessor>().Keyed<IDocumentProcessor>(FileTypeEnum.Doc);
            builder.RegisterType<PdfDocumentProcessor>().Keyed<IDocumentProcessor>(FileTypeEnum.Pdf);
            builder.RegisterType<XlsDocumentProcessor>().Keyed<IDocumentProcessor>(FileTypeEnum.Xls);

            builder.Populate(serviceProvider);

            IContainer applicationContainer = builder.Build();

            bool run = true;
            while (run)
            {
                var docProcessor = applicationContainer.Resolve<IDocumentProcessorClient>();

                Console.WriteLine("Enter the document type you want to process.");
                Console.WriteLine("0 - .doc");
                Console.WriteLine("1 - .pdf");
                Console.WriteLine("2 - .xls");

                int inputTYpe;
                while (!int.TryParse(Console.ReadLine(), out inputTYpe))
                {
                    Console.WriteLine("Invalid input. Please try again!");
                }

                var docInf = new DocumentInfo()
                {
                    FilePath = "C:\\Dev\\test.docx",
                    FileType = (FileTypeEnum)inputTYpe
                };

                Console.WriteLine(docProcessor.ProcessFile(docInf));

                Console.WriteLine("Press E to exit or any key to continue.");

                string exitInput = Console.ReadLine()?.ToUpper();
                run = exitInput != "E";
            }
           
        }
    }
}
