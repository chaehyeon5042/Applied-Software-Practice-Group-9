using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSummarizer
{
    public partial class PreviewForm : Form
    {
        private string summarizedText; // 요약된 텍스트를 저장할 변수

        // 생성자 수정: 요약된 텍스트를 파라미터로 받음
        public PreviewForm(string summarizedText)
        {
            InitializeComponent();
            this.summarizedText = summarizedText; // 요약된 텍스트 저장
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
                }
                else if (rdoOption == rdoStudy)
                {
                    //Study 파일
                    //pdf라서 제대로 구현이 된부분인데 보이는것에서 약간의 수정이 필요해 보이긴함
                    picBox_Study.Visible = true;
                    picBox_Study.Image = TextToImageConverter.ConvertTextToImage(summarizedText, picBox_Study.Width, picBox_Study.Height);
                }
                else
                {
                    //Report 파일
                    //수정해야할 부분
                    picBox_Report.Visible = true;
                    picBox_Report.Image = TextToImageConverter.ConvertTextToImage(summarizedText, picBox_Report.Width, picBox_Report.Height);
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            //Radio Button에서 선택된 파일로 파일명 자동 생성 및 폴더 자동 저장.
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