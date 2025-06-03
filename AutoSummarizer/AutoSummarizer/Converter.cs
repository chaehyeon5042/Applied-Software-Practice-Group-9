using System;
using System.IO;
using System.Linq;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Windows.Forms;
using iText.IO.Font;
using iText.Kernel.Font;
using static iText.Kernel.Font.PdfFontFactory;
using DocumentFormat.OpenXml.Packaging;
using System.Threading.Tasks;
namespace AutoSummarizer
{
    public static class Converter
    {
        ///</summary>
        ///PDF로 변환하여 지정 경로에 저장,경로반환
        ///</summary>
        ///<param name = "text">PDF에 담을 본문 텍스트</param>
        ///<param name = "outpudPdfPath">저장할 PDF 파일 경로</param>
        public static string ToPdf(string text,string outputPdfPath)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("변환할 텍스트가 없습니다.", nameof(text));
            if (string.IsNullOrEmpty(outputPdfPath)) 
                throw new ArgumentException("경로가 없습니다.",nameof(outputPdfPath));

            string fontPath;

            string windir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            string malgun = Path.Combine(windir, "Fonts", "malgun.ttf");
            if (File.Exists(malgun))
                fontPath = malgun;
            else
                throw new FileNotFoundException("한글 폰트 파일을 찾을 수 없습니다. 프로젝트에 NanumGothic-Regular.ttf 또는 시스템 malgun.ttf가 있어야 합니다.");


            System.Diagnostics.Debug.WriteLine($"[converter.ToPdf] text.Length = [text.Length]");
            try
            {
                var dir = Path.GetDirectoryName(outputPdfPath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                var writer = new PdfWriter(outputPdfPath);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                
                PdfFont font = PdfFontFactory.CreateFont(
                fontPath,
                PdfEncodings.IDENTITY_H,
                EmbeddingStrategy.PREFER_EMBEDDED
                );
                document.SetFont(font).SetFontSize(12);
                
                {
                    var filename = Path.GetFileName(outputPdfPath);

                    foreach (var line in text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None))
                        document.Add(new Paragraph(line));
                }
                document.Close();
                return outputPdfPath;
            }
            catch (Exception ex) 
                {
                MessageBox.Show($"PDF 변환 중 오류 발생:\n{ex.Message}", "PDF 생성 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
                }

        }
        
    }
}
