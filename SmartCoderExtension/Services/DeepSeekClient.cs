// Controls/DeepSeekClient.cs
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartCoderExtension.Utilities;

namespace SmartCoderExtension.Services
{
    public class DeepSeekClient
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<string> GenerateCodeAsync(string prompt)
        {
            var request = new
            {
                model = Constants.ModelName,
                messages = new[]
                {
                    new { role = "system", content = Constants.SystemPrompt },
                    new { role = "user", content = prompt }
                }
            };

            _client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Constants.ApiKey);

            var content = new StringContent(
                JsonConvert.SerializeObject(request),
                Encoding.UTF8,
                "application/json");

            try
            {
                Debug.WriteLine("发送请求: " + JsonConvert.SerializeObject(request));
                var response = await _client.PostAsync(Constants.ApiEndpoint, content); // 在此行设置断点
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync(); // 在此行设置断点
                Debug.WriteLine("收到响应: " + jsonResponse);
                return JObject.Parse(jsonResponse)["choices"][0]["message"]["content"].ToString();
            }
            catch (Exception ex)
            {
                // 添加日志记录
                Debug.WriteLine($"API 调用失败: {ex.Message}");
                throw;
            }
        }
    }
}