using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoSummarizer
{
    public static class Chunker
    {
        /// <summary>
        /// 문단(빈 줄) 단위로 분리한 뒤, maxChunkSize를 넘지 않도록 문단을 묶어 청크를 반환합니다.
        /// </summary>
        public static List<string> SplitToChunks(string text, int maxChunkSize)
        {
            var chunks = new List<string>();
            if (string.IsNullOrWhiteSpace(text) || maxChunkSize <= 0)
                return chunks;

            // 1) 문단 단위 분리: 빈 줄(\r\n\r\n 또는 \n\n) 기준으로
            var paragraphSplitter = new Regex(@"\r?\n\s*\r?\n", RegexOptions.Multiline);
            string[] paragraphs = paragraphSplitter.Split(text.Trim());

            var current = new StringBuilder();
            foreach (var para in paragraphs)
            {
                string p = para.Trim();
                if (p.Length == 0) continue;

                // 현재 청크에 이 문단을 추가해도 크기 내라면
                if (current.Length + p.Length + 2 <= maxChunkSize)
                {
                    if (current.Length > 0)
                        current.Append(Environment.NewLine + Environment.NewLine);
                    current.Append(p);
                }
                else
                {
                    // 크기를 넘는다면, 지금까지 쌓인 청크 저장
                    if (current.Length > 0)
                    {
                        chunks.Add(current.ToString());
                        current.Clear();
                    }

                    // 단일 문단이 maxChunkSize보다 크면, 강제로 자르기
                    if (p.Length > maxChunkSize)
                    {
                        for (int i = 0; i < p.Length; i += maxChunkSize)
                        {
                            int len = Math.Min(maxChunkSize, p.Length - i);
                            chunks.Add(p.Substring(i, len));
                        }
                    }
                    else
                    {
                        current.Append(p);
                    }
                }
            }

            // 마지막 남은 청크 추가
            if (current.Length > 0)
                chunks.Add(current.ToString());

            return chunks;
        }
    }
}

