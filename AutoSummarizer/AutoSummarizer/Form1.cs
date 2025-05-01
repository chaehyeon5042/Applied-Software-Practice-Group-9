using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSummarizer
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_FileUpload_Click(object sender, EventArgs e)
        {
            //파일 업로드 버튼 눌러서 파일 선택하면 텍스트 박스에 선택된 파일명(확장자 포함) 나오게 하기.
        }

        private void btn_Gen_Click(object sender, EventArgs e)
        {
            /*
            if (!string.IsNullOrEmpty(uploadedFilePath)) //파일 업로드 확인(수정 필요)
            {
                // 업로드 된 경우
                PreviewForm PF = new PreviewForm();
                PF.Owner = this;
                //Summarize 후 2번째 Form에서 Preview 보여주기
                PF.Show();
            }
            else
            {
                // 업로드가 안 된 경우 경고 메시지 표시
                MessageBox.Show(
                    "먼저 파일을 업로드해 주세요.",
                    "업로드 필요",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            */

            PreviewForm PF = new PreviewForm();
            PF.Owner = this;
            //Summarize 후 2번째 Form에서 Preview 보여주기
            PF.Show();
        }
    }
}
