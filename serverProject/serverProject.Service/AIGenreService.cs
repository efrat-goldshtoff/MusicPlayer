using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;
using serverProject.Core.Services;

namespace serverProject.Service
{
    public class AIGenreService : IAIGenreService
    {
        private readonly HttpClient _httpClient;
        private readonly string _openAiApiKey; // Or other AI service key
        private readonly string _openAiEndpoint; // Or other AI service endpoint

        public AIGenreService(HttpClient httpClient
            //, IConfiguration configuration
            )
        {
            _httpClient = httpClient;
            _openAiApiKey = Environment.GetEnvironmentVariable("OpenAI__ApiKey"); 
            _openAiEndpoint = Environment.GetEnvironmentVariable("OpenAI__Endpoint") ?? "https://api.openai.com/v1/chat/completions";
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_openAiApiKey}");
        }
        public async Task<List<string>> GetGenresFromTextAsync(string text)
        {
            // Example using OpenAI Chat Completions API
            var requestBody = new
            {
                model = "gpt-3.5-turbo", // or another suitable model
                messages = new[]
                {
                    new { role = "system", content = "You are a music genre classifier." +
                    " Extract relevant music genres from the given text." +
                    " Return a comma-separated list of genres, or 'unknown' if no clear genre is identified." },
                    new { role = "user", content = $"Text: \"{text}\"" }
                }
            };

            var response = await _httpClient.PostAsJsonAsync(_openAiEndpoint, requestBody);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
            {
                if (doc.RootElement.TryGetProperty("choices", out JsonElement choices) && choices.EnumerateArray().Any())
                {
                    var message = choices[0].GetProperty("message").GetProperty("content").GetString();
                    return message?.Split(',')
                        .Select(g => g.Trim().ToLower())
                        .Where(g => !string.IsNullOrEmpty(g) && g != "unknown")
                        .ToList() ?? new List<string>();
                }
            }
            return new List<string>();
        }
    }
}
