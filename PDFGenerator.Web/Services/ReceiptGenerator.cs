using DinkToPdf.Contracts;
using Microsoft.Extensions.DependencyInjection;
using PDFGenerator.Web.Models;
using PDFGenerator.Web.Services.Interfaces;
using System;

namespace PDFGenerator.Web.Services
{
    public class ReceiptGenerator : IReceiptGenerator
    {
        private readonly IPDFGenerator _pdfGenerator;
        private readonly IConverter _pdfDocumentToByteArrayConverter;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ReceiptGenerator(IPDFGenerator pdfGenerator, 
            IConverter pdfDocumentToByteArrayConverter,
            IServiceScopeFactory serviceScopeFactory)
        {
            _pdfGenerator = pdfGenerator ?? throw new ArgumentNullException(nameof(pdfGenerator));
            _pdfDocumentToByteArrayConverter = pdfDocumentToByteArrayConverter ?? throw new ArgumentNullException(nameof(pdfDocumentToByteArrayConverter));
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public byte[] GenerateReceipt(ReceiptDTO receipt)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var view = scope.ServiceProvider.GetRequiredService<ViewRender>();
                var receiptString = view.Render("Receipt/index", receipt);
                var receiptPDFDocument = _pdfGenerator.Generate(receiptString, null);
                return _pdfDocumentToByteArrayConverter.Convert(receiptPDFDocument);
            }
        }
    }
}
