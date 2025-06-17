using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.ExtendedProperties;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoSummarizer
{
    /// <summary>
    /// ChatService를 주입받아,
    /// 분할된 텍스트 청크를 순차적으로 요약
    /// </summary>
    public class PartialSummarizer
    {
        private readonly ChatService _chat;

        public PartialSummarizer(ChatService chatService)
        {
            _chat = chatService;
        }

        /// <summary>
        /// 분할된 텍스트 청크 리스트를 ChatGPT에 기존 요약본과 함께 순차 전송해,
        /// 해당 전송본에 대한 요약을 리스트에 저장
        /// </summary>
        public async Task<List<string>> SummarizeChunksStudy(List<string> chunks)
        {
            var chatService = new ChatService("OPENAI_API_KEY", model: "gpt-4o-mini");


            var partials = new List<string>();
            string summary = string.Empty;
            for (int i = 0; i < chunks.Count; i++)
            {
                string prompt = "다음 내용을 학습하기 편한 형식으로 한글로 요약해 주세요. 주제별로 요약이 잘 되어있어야 해요. 부족한 내용이 있다면 보충설명도 부탁합니다. 또한, 요약된 텍스트 내용은 다른 파일로(pdf)변환되니 고려해주세요:\n\n" +
                summary + chunks[i];

                summary = await _chat.SendToGptAsync(prompt);
                partials.Add(summary);
            }

            return partials;
        }
        public async Task<List<string>> SummarizeChunksReport(List<string> chunks)
        {
            var partials = new List<string>();
            string summary = string.Empty;
            for (int i = 0; i < chunks.Count; i++)
            {
                string prompt = "다음 내용을 제출을 위한 보고서 형식으로 한글로 요약해 주세요. 요약된 텍스트 내용은 다른 파일로(pdf)변환되니 고려해주세요:\n\n" +
                summary + chunks[i];

                summary = await _chat.SendToGptAsync(prompt);
                partials.Add(summary);
            }

            return partials;
        }
        public async Task<List<SlideModel>> SummarizeChunksPt(List<string> chunks)
        {
            var partials = new List<string>();
            string summary = string.Empty;
            //직렬화된 Json 텍스트 받아오기
            string prompt = $@"이 텍스트를 한국어로 요약한 후, 
                                발표용 PPT 슬라이드 구조를 JSON 형태로 만들어 주세요. 
                                JSON 형식은 반드시 아래와 같아야 하며, JSON텍스트를 제외한 다른 텍스트는 포함하지 마세요 바로 받은 텍스트를 배열에 넣고 PPTX로 변환할 예정입니다:
                            {{
                                ""slides"": [
                                    {{
                                    ""title"": ""First Slide Title"",
                                    ""bullets"": [
                                    ""Bullet 1"",
                                    ""Bullet 2"",
                                    ""Bullet 3""
                                                 ]   
                                    }},
                                                        // … 최대 10개 슬라이드
                                            ]
                            }}

              
                -title: 슬라이드 제목(20자 이내)
                -bullets: 5개 이하의 핵심 문장(각 10단어 이내)
                -START 와 END 사이가 해당 텍스트 입니다

                START
                {chunks[0]}
                END"; ;

            summary = await _chat.SendToGptAsync(prompt);
            var doc = JsonDocument.Parse(summary);
            var root = doc.RootElement.GetProperty("slides");
            
            var slides = new List<SlideModel>();   //역직렬화
            foreach(var slideEl in root.EnumerateArray())
            {
                var slide = new SlideModel
                {
                    Title = slideEl.GetProperty("title").GetString(),
                    Bullets = new List<string>()
                };
                foreach (var bulletEl in slideEl.GetProperty("bullets").EnumerateArray()) slide.Bullets.Add(bulletEl.GetString());
                slides.Add(slide);
            }
            return slides;
        }
    }
}


            

