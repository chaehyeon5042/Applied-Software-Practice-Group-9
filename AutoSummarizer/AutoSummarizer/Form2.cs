using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSummarizer
{
    public partial class PreviewForm : Form
    {
        private string summarizedFilePath; // 전달받은 요약 파일 경로 저장
        private string summarizedText;     // 미리보기용 텍스트

        // 생성자 수정: 파일 경로를 파라미터로 받음
        public PreviewForm(string summarizedFilePath, string summarizedText)
        {
            InitializeComponent();
            this.summarizedFilePath = summarizedFilePath;
            this.summarizedText = summarizedText;
        }

        // Text를 Image로 변환하는 static 클래스 -> pdf에서 추출한 텍스트를 이미지로 변환
        public static class TextToImageConverter
        {
            public static Image ConvertTextToImage(string text, int width, int height)
            {
                Bitmap bmp = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White); // 배경색 설정
                    Font font = new Font("Arial", 12); // 글꼴 및 크기 설정
                    g.DrawString(text, font, Brushes.Black, new RectangleF(0, 0, width, height));
                }
                return bmp;
            }
        }

        private void PreviewForm_Load(object sender, EventArgs e)
        {
            // PictureBox 초기화 및 UI에 추가
            picBox_Pre = new PictureBox { SizeMode = PictureBoxSizeMode.Zoom, BorderStyle = BorderStyle.FixedSingle, Visible = false };
            picBox_Study = new PictureBox { SizeMode = PictureBoxSizeMode.Zoom, BorderStyle = BorderStyle.FixedSingle, Visible = false };
            picBox_Report = new PictureBox { SizeMode = PictureBoxSizeMode.Zoom, BorderStyle = BorderStyle.FixedSingle, Visible = false };

            Panel panel1 = this.Controls.Find("panel1", true).FirstOrDefault() as Panel;
            Panel panel2 = this.Controls.Find("panel2", true).FirstOrDefault() as Panel;
            Panel panel3 = this.Controls.Find("panel3", true).FirstOrDefault() as Panel;

            // 패널이 존재하는지 확인
            if (panel1 != null && panel2 != null && panel3 != null)
            {
                // PictureBox를 패널에 추가
                panel1.Controls.Add(picBox_Pre);
                panel2.Controls.Add(picBox_Study);
                panel3.Controls.Add(picBox_Report);
            }
            else
            {
                //패널이 존재하지 않을경우
                MessageBox.Show("Panel 컨트롤을 찾을 수 없습니다. 디자이너에서 Panel 컨트롤의 이름을 확인해주세요.");
            }
        }

        //picbox에 요약된 텍스트를 이미지로 변환하여 표시 -> 수정이 필요 현재는 txt를 이미지로 변환하는 형태만 구현이 되어있음
        // ppt와 word파일등은 구현이 안되어있는데 이부분은 쿼리부분에 추가하여 파일을 ppt나 word형태로 변환하여 출력을 받아서 첫페이지나 두번째페이지를 선택해서 이미지를 받아올수 있도록 해야할것 같음
        private void rdoBtn_CheckedChanged(object sender, EventArgs e)
        {
            // 모든 PictureBox를 숨김
            picBox_Pre.Visible = false;
            picBox_Study.Visible = false;
            picBox_Report.Visible = false;

            var rdoOption = sender as RadioButton;

            if (rdoOption != null)
            {
                if (rdoOption == rdoPresentation)
                {
                    //Presentaion 파일
                    //수정해야할 부분
                    picBox_Pre.Visible = true;
                    picBox_Pre.Image = TextToImageConverter.ConvertTextToImage(summarizedText, picBox_Pre.Width, picBox_Pre.Height);
                    // picBox_Pre.Image = GenerateImageFromFileContent(summarizedFilePath, picBox_Pre.Width, picBox_Pre.Height);
                }
                else if (rdoOption == rdoStudy)
                {
                    //Study 파일
                    //pdf라서 제대로 구현이 된부분인데 보이는것에서 약간의 수정이 필요해 보이긴함
                    picBox_Study.Visible = true;
                    picBox_Study.Image = TextToImageConverter.ConvertTextToImage(summarizedText, picBox_Study.Width, picBox_Study.Height);
                    //picBox_Study.Image = GenerateImageFromFileContent(summarizedFilePath, picBox_Study.Width, picBox_Study.Height);
                }
                else
                {
                    //Report 파일
                    //수정해야할 부분
                    picBox_Report.Visible = true;
                    picBox_Report.Image = TextToImageConverter.ConvertTextToImage(summarizedText, picBox_Report.Width, picBox_Report.Height);
                    //picBox_Report.Image = GenerateImageFromFileContent(summarizedFilePath, picBox_Report.Width, picBox_Report.Height);
                }
            }
        }
                //private Image GenerateImageFromFileContent(string filePath, int maxWidth, int maxHeight)
        //{
        //    string extension = Path.GetExtension(filePath).ToLower();
        //    string content = string.Empty;
        
        //    if (extension == ".pdf")
        //    {
        //        content = ExtractTextFromPdf(filePath);
        //    }
        //    else if (extension == ".ppt" || extension == ".pptx")
        //    {
        //        content = ExtractTextFromPpt(filePath);
        //    }
        //    else if (extension == ".doc" || extension == ".docx")
        //    {
        //        content = ExtractTextFromWord(filePath);
        //    }
        //    else
        //    {
        //        MessageBox.Show("지원하지 않는 파일 형식입니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return null;
        //    }
        
        //    return GenerateImageFromText(content, maxWidth, maxHeight);
        //}
        
        //private string ExtractTextFromPdf(string pdfFilePath)
        //{
        //    StringBuilder text = new StringBuilder();
        
        //    try
        //    {
        //        using (PdfReader reader = new PdfReader(pdfFilePath))
        //        {
        //            using (PdfDocument document = new PdfDocument(reader))
        //            {
        //                for (int i = 1; i <= document.GetNumberOfPages(); i++)
        //                {
        //                    PdfPage page = document.GetPage(i);
        //                    ITextExtractionStrategy strategy = new LocationTextExtractionStrategy();
        //                    string pageText = PdfTextExtractor.GetTextFromPage(page, strategy);
        //                    text.Append(pageText);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"PDF 추출 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        
        //    return text.ToString();
        //}
        
        //private string ExtractTextFromPpt(string pptFilePath)
        //{
        //    StringBuilder text = new StringBuilder();
        //    PowerPoint.Application pptApp = null;
        //    PowerPoint.Presentation pptPresentation = null;
        
        //    try
        //    {
        //        pptApp = new PowerPoint.Application();
        //        pptPresentation = pptApp.Presentations.Open(pptFilePath, MsoTriState.msoFalse, MsoTriState.msoFalse, MsoTriState.msoFalse);
        
        //        foreach (PowerPoint.Slide slide in pptPresentation.Slides)
        //        {
        //            foreach (PowerPoint.Shape shape in slide.Shapes)
        //            {
        //                if (shape.HasTextFrame == MsoTriState.msoTrue)
        //                {
        //                    text.Append(shape.TextFrame.TextRange.Text);
        //                    text.Append(Environment.NewLine);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"PPT 추출 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        if (pptPresentation != null)
        //        {
        //            pptPresentation.Close();
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(pptPresentation);
        //            pptPresentation = null;
        //        }
        //        if (pptApp != null)
        //        {
        //            pptApp.Quit();
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(pptApp);
        //            pptApp = null;
        //        }
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //    }
        
        //    return text.ToString();
        //}
        
        //private string ExtractTextFromWord(string wordFilePath)
        //{
        //    StringBuilder text = new StringBuilder();
        //    Word.Application wordApp = null;
        //    Word.Document wordDocument = null;
        
        //    try
        //    {
        //        wordApp = new Word.Application();
        //        wordDocument = wordApp.Documents.Open(wordFilePath);
        
        //        foreach (Word.Paragraph paragraph in wordDocument.Paragraphs)
        //        {
        //            text.Append(paragraph.Range.Text);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Word 추출 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        if (wordDocument != null)
        //        {
        //            wordDocument.Close();
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(wordDocument);
        //            wordDocument = null;
        //        }
        //        if (wordApp != null)
        //        {
        //            wordApp.Quit();
        //            System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
        //            wordApp = null;
        //        }
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //    }
        
        //    return text.ToString();
        //}
        
        //private Bitmap GenerateImageFromText(string text, int maxWidth, int maxHeight)
        //{
        //    // 1. 글꼴 및 기타 설정
        //    Font font = new Font("Arial", 12); // 적절한 글꼴 선택
        //    Color textColor = Color.Black;
        //    Color backColor = Color.White;
        //    int padding = 10;
        
        //    // 2. 텍스트 측정
        //    // 임시 비트맵을 생성하여 그래픽 컨텍스트 얻기
        //    using (Bitmap tempBitmap = new Bitmap(1, 1))
        //    {
        //        using (Graphics tempGraphics = Graphics.FromImage(tempBitmap))
        //        {
        //            SizeF textSize = tempGraphics.MeasureString(text, font, maxWidth - (2 * padding));
        
        //            // 3. 최종 비트맵 생성
        //            int width = (int)Math.Min(maxWidth, textSize.Width + (2 * padding));
        //            int height = (int)textSize.Height + (2 * padding);
        
        //            Bitmap bmp = new Bitmap(width, height);
        
        //            using (Graphics gfx = Graphics.FromImage(bmp))
        //            {
        //                //gfx.SmoothingMode = SmoothingMode.AntiAlias;  //선택 사항이지만 텍스트를 더 좋게 보이게 할 수 있습니다.
        //                gfx.Clear(backColor);
        
        //                // 4. 텍스트 그리기
        //                gfx.DrawString(text, font, new SolidBrush(textColor), new RectangleF(padding, padding, width - (2 * padding), height - (2 * padding)));
        //            }
        
        //            return bmp;
        //        }
        //    }
        //}

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 전달받은 요약 파일 경로 사용
                if (!File.Exists(summarizedFilePath))
                {
                    MessageBox.Show("요약된 파일이 존재하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2. 과목명 추출 (라디오 버튼 기반)
                string subjectName = "Report";
                if (rdoPresentation.Checked) subjectName = "Presentation";
                else if (rdoStudy.Checked) subjectName = "Study";

                // 3. 원본 파일명 정보 추출
                string originalName = Path.GetFileName(summarizedFilePath);
                string nameWithoutExt = Path.GetFileNameWithoutExtension(originalName);
                string extension = Path.GetExtension(originalName);

                // 4. 날짜 추가
                string date = DateTime.Now.ToString("yyyy-MM-dd");

                // 5. 파일명 구성
                string fileName = $"{subjectName}_{nameWithoutExt}_{date}{extension}";
                string targetPath = "";

                // 6. 저장 방식 선택
                DialogResult choice = MessageBox.Show(
                    "저장 방식을 선택하세요:\n\n예: 직접 저장 위치 및 파일명 지정\n아니오: 바탕화면에 과목명 폴더 자동 저장",
                    "저장 옵션",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (choice == DialogResult.Cancel) return;

                string directoryPath = "";
                if (choice == DialogResult.Yes)
                {
                    using (SaveFileDialog dialog = new SaveFileDialog())
                    {
                        dialog.Title = "요약 파일을 저장할 위치와 이름을 선택하세요.";
                        dialog.Filter = "모든 파일 (*.*)|*.*";
                        dialog.FileName = fileName;

                        if (dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            directoryPath = Path.GetDirectoryName(dialog.FileName);
                            fileName = Path.GetFileName(dialog.FileName);
                        }
                        else return;
                    }
                }
                else if (choice == DialogResult.No)
                {
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    directoryPath = Path.Combine(desktopPath, subjectName);
                    Directory.CreateDirectory(directoryPath);
                }

                // 7. 최종 경로 결정
                string fullPath = Path.Combine(directoryPath, fileName);

                // 8. 파일 중복 여부 확인
                if (File.Exists(fullPath))
                {
                    DialogResult overwriteChoice = MessageBox.Show(
                        "같은 이름의 파일이 이미 존재합니다.\n덮어쓰시겠습니까?",
                        "파일 중복 경고",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning);

                    if (overwriteChoice == DialogResult.No)
                    {
                        string newFileName = PromptForNewFileName(fileName);
                        if (string.IsNullOrWhiteSpace(newFileName)) return;
                        fullPath = Path.Combine(directoryPath, newFileName);
                    }
                    else if (overwriteChoice == DialogResult.Cancel)
                    {
                        return;
                    }
                }

                // 9. 파일 복사
                File.Copy(summarizedFilePath, fullPath, overwrite: true);
                MessageBox.Show("요약 파일이 저장되었습니다:\n" + fullPath, "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("저장 중 오류 발생: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string PromptForNewFileName(string oldName)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 150;
                prompt.Text = "파일 이름 다시 입력";

                Label textLabel = new Label() { Left = 20, Top = 20, Text = "새 파일 이름(.pdf 포함):", Width = 300 };
                TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340, Text = oldName };

                Button confirmation = new Button() { Text = "확인", Left = 270, Width = 90, Top = 80, DialogResult = DialogResult.OK };
                prompt.AcceptButton = confirmation;

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);

                return (prompt.ShowDialog() == DialogResult.OK) ? inputBox.Text : null;
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            //이 창만 닫고 이전 창으로 돌아가기
            this.Close();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            //프로그램 종료
            Application.Exit();
        }
    }
}
