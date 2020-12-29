using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AubreyRussellClient.Repository
{
    public class ResumeHttpRepository
    {
        private readonly HttpClient _client;
        public ResumeHttpRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<CodeSnippet>> GetCodeSnipperts()
        {
            var response = await _client.GetAsync("https://localhost:44381/api/GetCodeSnippets");
            var content = await response.Content.ReadAsStringAsync();
            var codeSnippets = JsonSerializer.Deserialize<List<CodeSnippet>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return codeSnippets;
        }
    }
}
