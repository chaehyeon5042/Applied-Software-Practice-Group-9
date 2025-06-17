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
                // 1) 지원할 파일 확장자 목록
                ofd.Filter =
                    "지원되는 파일 (*.pdf;*.pptx)|*.pdf;*.pptx|" +
                    "PDF 파일 (*.pdf)|*.pdf|" +
                    "PowerPoint 파일 (*.pptx)|*.pptx|" +
                    "모든 파일 (*.*)|*.*";

                ofd.Title = "요약할 파일을 선택하세요";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    uploadedFilePath = ofd.FileName;
                    extractedText = string.Empty;
                    txt_FileName.Text = Path.GetFileName(uploadedFilePath);
                    MessageBox.Show($"파일이 업로드 되었습니다:\n{uploadedFilePath}",
                                    "업로드 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private string TempConvertToPptx(List<SlideModel> slides)
        {
            string tempDir = Path.GetTempPath();
            string tempFileName = $"summary_{Guid.NewGuid():N}.Pptx";
            string tempPath = Path.Combine(tempDir, tempFileName);
            CreatePresentation.NewPres(slides,tempPath);
            return tempPath;
        }


        private async Task GenerateAndPreviewAllAsync(List<string> chunks)
        {
            try
            {
                int step = 0;
                const int totalSteps = 3;
                using (ProgressDialog progressDialog = new ProgressDialog())
                {
                    progressDialog.Show();
                    string openai_KEY = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
                    var chatService = new ChatService(openai_KEY, model: "gpt-4o-mini");
                    var summarizer = new PartialSummarizer(chatService);

                    string tempStudy = await summarizer.SummarizeChunksStudy(chunks);
                    progressDialog.Report(++step * 100 / totalSteps);

                    string tempReport = await summarizer.SummarizeChunksReport(chunks);
                    progressDialog.Report(++step * 100 / totalSteps);

                    List<SlideModel> slides = await summarizer.SummarizeChunksPt(chunks);
                    progressDialog.Report(++step * 100 / totalSteps);

                    step = 0;
                    progressDialog.Close();




                    string studyPdfPath = TempConvertToPdf(tempStudy);
                    string reportPdfPath = TempConvertToPdf(tempReport);
                    string ptPath = TempConvertToPptx(slides);

                    using (PreviewForm preview = new PreviewForm(studyPdfPath, reportPdfPath, ptPath, uploadedFilePath))
                    {
                        preview.ShowDialog(this);
                    }
                }
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
