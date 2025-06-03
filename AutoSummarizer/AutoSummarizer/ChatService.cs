using System.Threading.Tasks;
using OpenAI.Chat;   // ChatClient,
using OpenAI;


namespace AutoSummarizer
{
    /// <summary>
    /// OpenAI v2.1.0 SDK 의 ChatClient 래퍼
    /// </summary>
    public class ChatService
    {
        private readonly ChatClient chatClient;

        public ChatService(string apiKey, string model = "gpt-3.5-turbo")
        {
            // 모델 이름과 API 키를 직접 문자열로 넘깁니다
            chatClient = new ChatClient(model: model, apiKey: apiKey);
            
        }

        /// <summary>
        /// 단일 프롬프트를 보내고, ChatGPT 응답(Content[0].Text)을 반환
        /// </summary>
        public async Task<string> SendToGptAsync(string prompt)
        {
              
            ChatCompletion completion = await chatClient.CompleteChatAsync(prompt);

            if (completion.Content.Count > 0)
                return completion.Content[0].Text.Trim();

            return string.Empty;
        }
    }
}