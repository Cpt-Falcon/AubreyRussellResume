using Entities.Models;
using Microsoft.Extensions.Configuration;
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

        private IConfiguration wasmConfiguration;

        public ResumeHttpRepository(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            this.wasmConfiguration = configuration;
        }

        public async Task<Resume> GetResumeContent()
        {
            var builder = new UriBuilder(this.wasmConfiguration["restAPIBasePath"] + "api/Resume/GetResumeContent");
            int port;
            if ((port = int.Parse(this.wasmConfiguration["port"])) > 0)
            {
                builder.Port = port;
            }

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
