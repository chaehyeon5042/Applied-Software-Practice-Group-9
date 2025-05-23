﻿using System;
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
                ofd.Filter = "PDF Files (*.pdf)|*.pdf";
                ofd.Title = "요약할 PDF 파일을 선택하세요";
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

        private async void btn_Gen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uploadedFilePath))
            {
                MessageBox.Show("먼저 PDF 파일을 업로드해 주세요.", "업로드 필요", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btn_Gen.Enabled = false;

            try
            {
                // 1) PDF → 전체 텍스트
                string allText = TextExtractor.ExtractAllText(uploadedFilePath);

                // 2) 문단 단위로 5000자 청크 분할
                List<string> chunks = Chunker.SplitToChunks(allText, 5000);

                // 3) ChatService 및 PartialSummarizer 초기화
                string apiKey = "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" ?? throw new InvalidOperationException("OPENAI_API_KEY가 설정되어 있지 않습니다.");
                var chatService = new ChatService(apiKey, model: "gpt-3.5-turbo");

                var summarizer = new PartialSummarizer(chatService);

                // 4) 1차 요약 수행
                List<string> temp = await summarizer.SummarizeChunksAsync(chunks);

                // 5) 부분 요약 합치기
                string combined = string.Join(Environment.NewLine + Environment.NewLine, temp);

                // 6) GPT 담당이 생성한 PDF 파일 경로 확보 (예시 경로)
                //현재는 정적경로 사용중, 합의된 경로를 사용하거나 동적경로를 사용할 필요가 있음.
                string summarizedFilePath = @"C:\\Temp\\GPT_Summary_Output.pdf"; // 경로만 읽어옴

                // 7) 미리보기 폼 호출 (파일 경로 전달)
                using (var resultForm = new PreviewForm(summarizedFilePath, combined))
                {
                    resultForm.ShowDialog(this);
                }


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
