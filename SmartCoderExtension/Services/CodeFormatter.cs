// Controls/CodeFormatter.cs
using System.Text.RegularExpressions;

namespace SmartCoderExtension.Services
{
    public static class CodeFormatter
    {
        public static string Format(string code)
        {
            // 移除多余空行
            code = Regex.Replace(code, @"(\r\n){3,}", "\r\n\r\n");
            // 替换4空格为Tab
            return code.Replace("    ", "\t");
        }
    }
}