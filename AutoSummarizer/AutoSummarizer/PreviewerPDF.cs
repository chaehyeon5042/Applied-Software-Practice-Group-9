
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumViewer;
using System.IO;

namespace AutoSummarizer
{
    public static class PreviewerPDF
    {
        public static void PreviewPagePDF(string pdfPath, PictureBox picturebox, int dpi = 150)
        {
            if (string.IsNullOrEmpty(pdfPath)) { throw new ArgumentException("경로를 찾을 수 없습니다.", nameof(pdfPath)); }
            if (!System.IO.File.Exists(pdfPath)) { throw new System.IO.FileNotFoundException("파일을 찾을 수 없습니다."); }
            if (picturebox == null) { throw new ArgumentException(nameof(picturebox)); }
            var doc = PdfDocument.Load(pdfPath);

            Image img = doc.Render(
                page: 0,
                dpiX: dpi,
                dpiY: dpi,
                PdfRenderFlags.Annotations
                );
            picturebox.Image?.Dispose();
            picturebox.Image = img;
            picturebox.SizeMode = PictureBoxSizeMode.Zoom;
            doc.Dispose();
        }
    }
}
