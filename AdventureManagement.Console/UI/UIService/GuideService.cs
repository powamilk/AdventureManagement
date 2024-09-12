using AdventureManagementConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AdventureManagementConsole.UI.UIService
{
    public class GuideService
    {
        private readonly HttpClient _httpClient;

        public GuideService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7191/api/");
        }

        public async Task<List<GuideModel>> GetAllGuidesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<GuideModel>>("guides");
        }

        public async Task CreateGuideAsync(object guide)
        {
            var response = await _httpClient.PostAsJsonAsync("guides", guide);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateGuideAsync(int id, object guide)
        {
            var response = await _httpClient.PutAsJsonAsync($"guides/{id}", guide);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteGuideAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"guides/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

}
