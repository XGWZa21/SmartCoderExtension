// Controls/Constants.cs
using System;

namespace SmartCoderExtension.Utilities
{
    public static class Constants
    {
        public static string ApiKey =>
            Environment.GetEnvironmentVariable("sk-a699e21973f94988baf61596875ac5d5");

        public const string ApiEndpoint = "https://api.deepseek.com/v1/chat/completions";
        public const string ModelName = "deepseek-chat";
        public const string SystemPrompt = "你是一个专业的全栈开发助手，请生成简洁高效的代码，只返回代码不包含解释";
    }
}