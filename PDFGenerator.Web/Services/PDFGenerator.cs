using DinkToPdf;
using PDFGenerator.Web.Services.Interfaces;
using System;

namespace PDFGenerator.Web.Services
{
    public class PDFGenerator : IPDFGenerator
	{
		public HtmlToPdfDocument Generate(string content, string userStyleSheet)
		{
			var doc = new HtmlToPdfDocument()
			{
				GlobalSettings = {
					ColorMode = ColorMode.Color,
					Orientation = Orientation.Portrait,
					PaperSize = PaperKind.A4Plus,

				},
				Objects = {
					new ObjectSettings() {
						PagesCount = true,
						HtmlContent = content,
						WebSettings = {
							DefaultEncoding = "utf-8",
							UserStyleSheet = userStyleSheet,
						},
						FooterSettings =
						{
							FontName = "Arial",
							FontSize = 9,
							Line = false,
							Spacing = 1.8,
							Left = $"© {DateTime.Now.Year} Wedio \n Generated on (UTC): {DateTime.UtcNow}",
							Right = "Page [page] / [toPage]"
						}
					}
				}
			};
			return doc;
		}
	}
}
