using DinkToPdf;

namespace PDFGenerator.Web.Services.Interfaces
{
    public interface IPDFGenerator
    {
        public HtmlToPdfDocument Generate(string content, string userStyleSheet);
    }
}
