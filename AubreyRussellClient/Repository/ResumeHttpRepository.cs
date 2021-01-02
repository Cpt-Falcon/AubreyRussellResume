using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace AubreyRussellClient.Repository
{
    public class ResumeHttpRepository
    {
        private readonly HttpClient _client;
        public ResumeHttpRepository(HttpClient client)
        {
            _client = client;
        }

        public async Task<Resume> GetResumeContent()
        {
            var builder = new UriBuilder("https://localhost/api/Resume/GetResumeContent");
            builder.Port = 44381;
            var query = HttpUtility.ParseQueryString(builder.Query);

            // For now just hardcode my email address
            query["resumePersonEmail"] = "arusse02@gmail.com";
            builder.Query = query.ToString();
            string result = builder.ToString();
            var response = await _client.GetAsync(result);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Resume>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }
    }
}
