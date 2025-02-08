// Controls/DeepSeekClient.cs
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

            var response = await _client.PostAsync(Constants.ApiEndpoint, content);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JObject.Parse(jsonResponse)["choices"][0]["message"]["content"].ToString();
        }
    }
}