using PDFGenerator.Web.Models;

namespace PDFGenerator.Web.Services.Interfaces
{
    public interface IReceiptGenerator
    {
        byte[] GenerateReceipt(ReceiptDTO receipt);
    }
}
