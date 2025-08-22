using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;


namespace YourApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public EmployeesController(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task<IActionResult> Index()
        {
            var baseUrl  = "http://localhost:5225/api/";
            var endpoint =  "employee";
            var token    = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI1Iiwicm9sZSI6IkhSIiwibmJmIjoxNzU1ODM5NDU3LCJleHAiOjE3NTU5MjU4NTcsImlhdCI6MTc1NTgzOTQ1N30.VAeP17c6I_JPq7y0AfSxiW8aZ8DpujHcyjLqVKBueR0";

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = $"API error: {(int)response.StatusCode} {response.ReasonPhrase}";
                return View(Enumerable.Empty<Employee>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            
            List<Employee> employees;
            try
            {
                employees = JsonSerializer.Deserialize<List<Employee>>(json, opts) ?? new();
            }
            catch
            {
                // Fallback for wrapped shape: { data: [ ... ] }
                using var doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("data", out var data) && data.ValueKind == JsonValueKind.Array)
                {
                    employees = JsonSerializer.Deserialize<List<Employee>>(data.GetRawText(), opts) ?? new();
                }
                else
                {
                    employees = new();
                }
            }

            return View(employees);
        }
    }
}
