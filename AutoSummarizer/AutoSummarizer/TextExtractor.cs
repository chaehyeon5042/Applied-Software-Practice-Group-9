using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSummarizer
{
    public static class TextExtractor
    {
        public static string ExtractAllText(string pdfPath)
        {
            var result = new List<string>();

            using (var reader = new PdfReader(pdfPath))
            using (var pdfDoc = new PdfDocument(reader))
            {
                int pageCount = pdfDoc.GetNumberOfPages();
                for (int i = 1; i < pageCount; i++)
                {
                    result.Add(ExtractPageText(pdfDoc, i));
                }
                return string.Join(Environment.NewLine + Environment.NewLine, result);
            }
        }
        private static string ExtractPageText(PdfDocument pdfDoc, int pageNumber)
        {
            var strategy = new SimpleTextExtractionStrategy();
            return PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(pageNumber), strategy);
        }
    }
}
