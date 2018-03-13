namespace TemplateMethod.DocumentProcessor
{
    public interface IDocumentProcessor
    {
        string Execute(string filePath);
    }
}