using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;
using Spire.Presentation;
using Spire.Presentation.Drawing;
using NPOI.SS.Formula.Functions;
using DocumentFormat.OpenXml.EMMA;
using SkiaSharp;
using System.Windows.Forms;


namespace AutoSummarizer
{   public class PreviewPptx
    {   
        ///<summary>
        ///프리뷰용 이미지를 생성
        ///</summary>
        public static void PreviewPres(string path,PictureBox picbox)
        {
            Presentation presentation = new Presentation();
            try
            {
                presentation.LoadFromFile(path);
                ISlide slide = presentation.Slides[0];
                Image image = slide.SaveAsImage(400, 300);
                picbox.Image = image;
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }

    //슬라이드 제목과 내용을 위한 객체 생성
    public class SlideModel
    {
        public string Title { get; set; }
        public List<string> Bullets { get; set; }
    }
    //프레젠테이션 생성
    public static class CreatePresentation
    {   
        public static void NewPres(List<SlideModel> slides, string filepath)
        {
            using (Presentation presentation = new Presentation())
            {
                presentation.Slides.RemoveAt(0);

                foreach (SlideModel SlideModels in slides)
                {
                    ISlide slide = presentation.Slides.Append(SlideLayoutType.TitleAndObject);
                    IAutoShape shape = slide.Shapes[0] as IAutoShape;
                    TextRange textRange = shape.TextFrame.TextRange;
                    textRange.LatinFont = new TextFont("Malgun Gothic");
                    textRange.FontHeight = 21;
                    shape.TextFrame.Text = SlideModels.Title;

                    if (SlideModels.Bullets != null && SlideModels.Bullets.Count > 0)
                    {
                        shape = slide.Shapes[1] as IAutoShape;

                        foreach (string bullets in SlideModels.Bullets)
                        {
                            textRange.FontHeight = 15;
                            TextParagraph textParagraph = new TextParagraph();
                            textParagraph.Text = bullets;
                            textParagraph.Alignment = TextAlignmentType.Left;
                            textParagraph.TextRanges[0].Fill.FillType = FillFormatType.Solid;
                            textParagraph.TextRanges[0].Fill.SolidColor.Color = Color.Black;
                            textParagraph.BulletType = TextBulletType.Symbol;
                            shape.TextFrame.MarginTop = 15;
                            shape.TextFrame.Paragraphs.Append(textParagraph);
                        }
                    }
                }

            presentation.DocumentProperty.Application = "AutoSummarizer Presentation";
            presentation.DocumentProperty.Author = "AutoSummarizer";
            presentation.DocumentProperty.Company = "KwangWoon University";
            presentation.DocumentProperty.Keywords = "";
            presentation.DocumentProperty.Comments = "This File was made with Autosummarizer";
            presentation.DocumentProperty.Category = "Presentation";
            presentation.DocumentProperty.Title = "";
            presentation.DocumentProperty.Subject = "Test";

            presentation.SaveToFile(filepath, FileFormat.Pptx2010);
            }
        }      
    }
}
