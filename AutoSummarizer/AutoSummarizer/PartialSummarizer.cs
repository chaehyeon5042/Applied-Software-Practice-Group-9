using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoSummarizer
{
    /// <summary>
    /// ChatService를 주입받아,
    /// 분할된 텍스트 청크를 순차적으로 요약합니다.
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
        /// 해당 전송본에 대한 요약을 리스트에 저장합니다.
        /// </summary>
        public async Task<List<string>> SummarizeChunksAsync(List<string> chunks)
        {
            var partials = new List<string>();
            string summary = string.Empty;
            for (int i = 0; i < chunks.Count; i++)
            {
                    string prompt = "다음 내용을 학습하기 편한 형식으로 한국어로 요약해 주세요:\n\n" +
                    summary + chunks[i];

                summary = await _chat.SendToGptAsync(prompt);
                partials.Add(summary);
            }

            return partials;
        }
    }
}
