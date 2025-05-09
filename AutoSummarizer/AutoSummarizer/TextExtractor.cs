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

        // 현재는 pdf로만 구현이 되어있어 ppt와 txt등 파일이 안되어 있어서 이부분을 추가해야 미리보기부분에서 제대로된 확인을 할수있음

    }
}
