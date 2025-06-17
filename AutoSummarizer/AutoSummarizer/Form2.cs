using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumViewer;
namespace AutoSummarizer
{
    public partial class PreviewForm : Form
    {
        string tempStudy;
        string tempReport;
        string tempPt;
        string DefaultPath;
        // 생성자 수정: 파일 경로를 파라미터로 받음
        public PreviewForm(string studypath, string reportpath, string ptpath, string defaultpath)
        {
            InitializeComponent();
            tempStudy = studypath;
            tempReport = reportpath;
            tempPt = ptpath;
            DefaultPath = defaultpath;

            PreviewerPDF.PreviewPagePDF(tempStudy, picBox_Study);
            PreviewerPDF.PreviewPagePDF(tempReport, picBox_Report);
            PreviewPptx.PreviewPres(tempPt, picBox_Pre);

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            // 1) 저장할 임시 파일 결정
            string SelectedDirectory;
            if (rdoPresentation.Checked)
                SelectedDirectory = tempPt;
            else if (rdoStudy.Checked)
                SelectedDirectory = tempStudy;
            else
                SelectedDirectory = tempReport;

            try
            {
                // 2) 기본 파일 존재 여부 체크
                if (!File.Exists(DefaultPath))
                {
                    MessageBox.Show("기본 파일이 존재하지 않습니다.", "오류",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 3) 용도(subject) 결정
                string subjectName = rdoPresentation.Checked ? "Presentation"
                                  : rdoStudy.Checked ? "Study"
                                  : "Report";

                // 4) 원본 파일명 & 확장자 분리
                string originalName = Path.GetFileName(DefaultPath);
                string nameWithoutExt = Path.GetFileNameWithoutExtension(originalName);
                string extension = Path.GetExtension(SelectedDirectory);

                // 5) 날짜 추가
                string date = DateTime.Now.ToString("yyyy-MM-dd");

                // 6) 기본 파일명 조합
                string fileName = $"{subjectName}_{nameWithoutExt}_{date}{extension}";

                // 7) 저장 방식 선택
                var choice = MessageBox.Show(
                    "저장 방식을 선택하세요:\n\n" +
                    "예: 직접 저장 위치 및 파일명 지정\n" +
                    "아니오: 바탕화면에 과목명 폴더 자동 저장",
                    "저장 옵션",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                if (choice == DialogResult.Cancel) return;

                // 8) 저장할 폴더 결정
                string directoryPath;
                if (choice == DialogResult.Yes)
                {
                    using (var sfd = new SaveFileDialog())
                    {
                        sfd.Title = "요약 파일 저장 위치 및 이름을 선택하세요";
                        sfd.Filter = "PowerPoint (*.pptx;*.ppt)|*.pptx;*.ppt|PDF (*.pdf)|*.pdf|텍스트 (*.txt)|*.txt|모든 파일 (*.*)|*.*";
                        sfd.FileName = fileName;

                        if (sfd.ShowDialog(this) != DialogResult.OK)
                            return;

                        directoryPath = Path.GetDirectoryName(sfd.FileName);
                        fileName = Path.GetFileName(sfd.FileName);
                    }
                }
                else // DialogResult.No
                {
                    var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    directoryPath = Path.Combine(desktop, subjectName);
                    Directory.CreateDirectory(directoryPath);
                }

                // 9) 최종 경로
                string fullPath = Path.Combine(directoryPath, fileName);

                // 10) 중복 파일 처리
                if (File.Exists(fullPath))
                {
                    var over = MessageBox.Show(
                        "같은 이름의 파일이 이미 존재합니다.\n덮어쓰시겠습니까?",
                        "파일 중복 경고",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Warning);

                    if (over == DialogResult.Cancel) return;
                    if (over == DialogResult.No)
                    {
                        int idx = 1;
                        string baseName = Path.GetFileNameWithoutExtension(fileName);
                        while (File.Exists(fullPath))
                        {
                            string tmp = $"{baseName}_{idx++}{extension}";
                            fullPath = Path.Combine(directoryPath, tmp);
                        }
                    }
                }

                // 11) 파일 복사
                File.Copy(SelectedDirectory, fullPath, overwrite: true);

                // 12) 저장 완료 메시지 & 폴더 열기 여부 묻기
                var openFolder = MessageBox.Show(
                    "요약 파일이 저장되었습니다:\n" + fullPath + "\n\n" +
                    "저장된 폴더를 열어보시겠습니까?",
                    "저장 완료",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (openFolder == DialogResult.Yes)
                {
                    // 탐색기에서 해당 폴더 열기
                    Process.Start(new ProcessStartInfo()
                    {
                        FileName = "explorer.exe",
                        Arguments = $"\"{directoryPath}\"",
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("저장 중 오류 발생:\n" + ex.Message, "오류",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private string PromptForNewFileName(string oldName)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 150;
                prompt.Text = "파일 이름 다시 입력";

                Label textLabel = new Label() { Left = 20, Top = 20, Text = "파일 이름 입력" + Path.GetExtension(oldName), Width = 300 };
                TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340, Text = oldName };

                Button confirmation = new Button() { Text = "확인", Left = 270, Width = 90, Top = 80, DialogResult = DialogResult.OK };
                prompt.AcceptButton = confirmation;

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);

                return (prompt.ShowDialog() == DialogResult.OK) ? inputBox.Text : null;
            }
        }
        private void Form_Closed(object sender, EventArgs e)
        {
            Close();
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            //이 창만 닫고 이전 창으로 돌아가기

            File.Delete(tempPt);
            File.Delete(tempReport);
            File.Delete(tempStudy);
            this.Close();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            //프로그램 종료
            File.Delete(tempPt);
            File.Delete(tempReport);
            File.Delete(tempStudy);
            Application.Exit();
        }

        private void PreviewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            File.Delete(tempPt);
            File.Delete(tempReport);
            File.Delete(tempStudy);
        }
    }
}
