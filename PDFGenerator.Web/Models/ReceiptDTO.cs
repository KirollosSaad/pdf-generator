namespace PDFGenerator.Web.Models
{
    public class ReceiptDTO
    {
        public bool LenderIsCompany { get; set; }
        public bool renterIsCompany { get; set; }
        public string LenderName { get; set; }
        public string LenderCompanyName { get; set; }
        public string LenderCompanyId { get; set; }
        public string LenderAddress { get; set; }
        public string LenderZip { get; set; }
        public string LenderCity { get; set; }
        public string RenterName { get; set; }
        public string RenterAddress { get; set; }
        public string RenterZip { get; set; }
        public string RenterCity { get; set; }
        public string RenterCompanyName { get; set; }
        public string RenterCompanyId { get; set; }
        public string AcceptedDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string OrderNumber { get; set; }
        public string TotalDaysPriceAfterMultipleDayDiscount { get; set; }
        public string RentalVatWithoutFee { get; set; }
        public string Currency { get; set; }
        public string TotalRentalPrice { get; set; }
    }
}
