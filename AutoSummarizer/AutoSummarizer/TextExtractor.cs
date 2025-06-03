using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using A = DocumentFormat.OpenXml.Drawing;
using System.IO;


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
                return string.Join(Environment.NewLine, result);
            }
        }
        private static string ExtractPageText(PdfDocument pdfDoc, int pageNumber)
        {
            var strategy = new SimpleTextExtractionStrategy();
            return PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(pageNumber), strategy);
        }
        public static string ExtractpptxText(string pptxpath)
        {
            var texts = new List<string>();
            var doc = PresentationDocument.Open(pptxpath, false);
            var slides = doc.PresentationPart.SlideParts;

            foreach (var slidePart in slides)
            {
                foreach (var txt in slidePart.Slide.Descendants<A.Text>())
                {
                    texts.Add(txt.Text);
                }
            }
            return string.Join("\n\n", texts);
        }
    }
}
