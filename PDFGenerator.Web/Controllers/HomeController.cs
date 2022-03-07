using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PDFGenerator.Web.Models;
using PDFGenerator.Web.Services.Interfaces;
using System;
using System.Diagnostics;

namespace PDFGenerator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReceiptGenerator _receiptGenerator;

        public HomeController(ILogger<HomeController> logger, IReceiptGenerator receiptGenerator)
        {
            _logger = logger;
            _receiptGenerator = receiptGenerator;
        }

        public IActionResult Index()
        {
            Test(x => x.Currency = "adsdas");
            var receiptData = new ReceiptDTO
            {
                AcceptedDate = "21-2-2022",
                Currency = "DKK",
                InvoiceNumber = "4076845405",
                LenderAddress = "Chr M Østergaards Vej",
                LenderCity = "Alex",
                LenderCompanyId = "sdfsdf-sfdsfgjhfgjh-fgh450",
                LenderCompanyName = "Wedio",
                LenderIsCompany = false,
                LenderName = "Valeriu Shustaovich",
                LenderZip = "25004",
                OrderNumber = "367763",
                RentalVatWithoutFee = "10",
                RenterAddress = "14 MSC st",
                RenterCity = "Cairo",
                RenterCompanyId = "hjkhj-544-sdf54-sdf",
                RenterCompanyName = "Wedio-2",
                renterIsCompany = false,
                RenterName = "kiro",
                RenterZip = "8546",
                TotalDaysPriceAfterMultipleDayDiscount = "254",
                TotalRentalPrice = "574"
            };
            var receipt = _receiptGenerator.GenerateReceipt(receiptData);
            return File(receipt, "application/pdf", "receipt.pdf");
        }

        private void Test(Action<ReceiptDTO> act)
        {
        }

        public IActionResult Test()
        {
            var receipt = new ReceiptDTO
            {
                AcceptedDate = "21-2-2022",
                Currency = "DKK",
                InvoiceNumber = "4076845405",
                LenderAddress = "Chr M Østergaards Vej",
                LenderCity = "Alex",
                LenderCompanyId = "sdfsdf-sfdsfgjhfgjh-fgh450",
                LenderCompanyName = "Wedio",
                LenderIsCompany = false,
                LenderName = "Valeriu Shustaovich",
                LenderZip = "25004",
                OrderNumber = "367763",
                RentalVatWithoutFee = "10",
                RenterAddress = "Chr M Østergaards Vej",
                RenterCity = "Alexnandria, EG",
                RenterCompanyId = "hjkhj-544-sdf54-sdf",
                RenterCompanyName = "Wedio-2",
                renterIsCompany = false,
                RenterName = "Valeriu Shustaovich 15",
                RenterZip = "8546",
                TotalDaysPriceAfterMultipleDayDiscount = "254",
                TotalRentalPrice = "574"
            };
            return View("Receipt/Index", receipt);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
