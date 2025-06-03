using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.Net.Http;
using iText.Kernel.Pdf.Navigation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Diagnostics;
using NPOI.OpenXmlFormats.Dml;
using iText.Commons.Utils;

namespace AutoSummarizer
{
    public partial class MainForm : Form
    {
        private string uploadedFilePath = string.Empty;
        private string extractedText = string.Empty;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_FileUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "All Supported Files (*.pdf;*.pptx)|*.pdf|*.pptx|";

                ofd.Title = "요약할 파일을 선택하세요";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    uploadedFilePath = ofd.FileName;
                    extractedText = string.Empty;
                    txt_FileName.Text = Path.GetFileName(uploadedFilePath);
                    MessageBox.Show($"파일이 업로드 되었습니다: \n{uploadedFilePath}", "업로드 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private string TempConvertToPdf(string summarized_text)
        {   
            if (string.IsNullOrWhiteSpace(summarized_text)) 
                throw new ArgumentException("텍스트가 비어 있습니다.");
                

            string tempDir = Path.GetTempPath();
            string tempFileName = $"summary_{Guid.NewGuid():N}.pdf";
            string tempPath = Path.Combine(tempDir, tempFileName);

            string createdPath = Converter.ToPdf(summarized_text, tempPath);

            if (string.IsNullOrWhiteSpace(createdPath) || !File.Exists(createdPath))
                throw new InvalidOperationException("PDF 생성에 실패했습니다.");

            return createdPath;
        }

            


        private async Task GenerateAndPreviewAllAsync(List<string> chunks)
        {
            try
            {
                
                var chatService = new ChatService("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", model: "gpt-4o-mini");
                var summarizer = new PartialSummarizer(chatService);

                List<string> tempStudy = await summarizer.SummarizeChunksStudy(chunks);
                List<string> tempReport = await summarizer.SummarizeChunksReport(chunks);
                List<string> tempPt = await summarizer.SummarizeChunksPt(chunks);

                string finalStudy = string.Join(Environment.NewLine + Environment.NewLine, tempStudy);
                string finalReport = string.Join(Environment.NewLine + Environment.NewLine, tempReport);
                string finalPt = string.Join(Environment.NewLine+ Environment.NewLine, tempPt);

                string studyPdfPath = TempConvertToPdf(finalStudy);
                string reportPdfPath = TempConvertToPdf(finalReport);
                string ptPath = TempConvertToPdf(finalPt);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생:\n{ex.Message}", "오류",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private async void btn_Gen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uploadedFilePath))
            {
                MessageBox.Show("먼저 파일을 업로드해 주세요.", "업로드 필요", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            btn_Gen.Enabled = false;

            try
            {
                string ext = Path.GetExtension(uploadedFilePath).ToLowerInvariant();
                string allText;
                if (ext == ".pdf")
                {
                    allText = TextExtractor.ExtractAllText(uploadedFilePath);
                }
                else if (ext == ".pptx")
                {
                    allText = TextExtractor.ExtractpptxText(uploadedFilePath);
                }
                else
                {
                    MessageBox.Show("지원하지 않는 파일 형식입니다.");
                    return;
                }

                List<string> chunks = Chunker.SplitToChunks(allText, 5000);

                await GenerateAndPreviewAllAsync(chunks);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류 발생:\n{ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_Gen.Enabled = true;
            }
        }
    }
}
