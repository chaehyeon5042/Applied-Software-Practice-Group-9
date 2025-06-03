using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.ExtendedProperties;
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
            var chatService = new ChatService("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", model: "gpt-4o-mini");


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
        public async Task<List<string>> SummarizeChunksPt(List<string> chunks)
        {
            var partials = new List<string>();
            string summary = string.Empty;

            
            for (int i = 0; i < chunks.Count; i++)
            {
                string prompt = "다음 내용을 발표자료 형식으로 바꿔주세요.\n\n" + summary + chunks[i];

                summary = await _chat.SendToGptAsync(prompt);
                partials.Add(summary);
            }


            return partials;
                }
            }
        }


