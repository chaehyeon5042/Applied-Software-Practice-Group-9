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
    public partial class PreviewForm: Form
    {
        public PreviewForm()
        {
            InitializeComponent();
        }

        private void rdoBtn_CheckedChanged(object sender, EventArgs e)
        {
            var rdoOption = sender as RadioButton;

            if (rdoOption != null)
            {
                if(rdoOption == rdoPresentation)
                {
                    //Presentaion 파일
                }
                else if(rdoOption == rdoStudy)
                {
                    //Study 파일
                }
                else
                {
                    //Report 파일
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
