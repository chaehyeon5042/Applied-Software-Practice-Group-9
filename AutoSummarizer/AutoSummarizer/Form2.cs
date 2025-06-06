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

            string SelectedDirectory;

            if(rdoPresentation.Checked)
            {
                SelectedDirectory = tempPt;
            }
            else if(rdoStudy.Checked)
            {
                SelectedDirectory = tempStudy;
            }
            else
            {
                SelectedDirectory = tempReport;
            }
            try
                {
                    // 1. 전달받은 요약 파일 경로 사용
                    if (!File.Exists(DefaultPath))
                    {
                        MessageBox.Show("기본 파일이 존재하지 않습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. 용도 추출 (라디오 버튼 기반)
                    string subjectName = "Report";
                    if (rdoPresentation.Checked) subjectName = "Presentation";
                    else if (rdoStudy.Checked) subjectName = "Study";

                    // 3. 원본 파일명 정보 추출
                    string originalName = Path.GetFileName(DefaultPath);
                    string nameWithoutExt = Path.GetFileNameWithoutExtension(originalName);
                    string extension = Path.GetExtension(SelectedDirectory);

                    // 4. 날짜 추가
                    string date = DateTime.Now.ToString("yyyy-MM-dd");

                    // 5. 파일명 구성
                    string fileName = $"{subjectName}_{nameWithoutExt}_{date}{extension}";

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
                    File.Copy(SelectedDirectory, fullPath, overwrite: true);
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
