using AdventureManagementConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AdventureManagementConsole.UI.UIService
{
    public class AdventureService
    {
        private readonly HttpClient _httpClient;

        public AdventureService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7191/api/");
        }

        public async Task<List<AdventureModel>> GetAllAdventuresAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<AdventureModel>>("adventures");
        }

        public async Task CreateAdventureAsync(object adventure)
        {
            var response = await _httpClient.PostAsJsonAsync("adventures", adventure);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateAdventureAsync(int id, object adventure)
        {
            var response = await _httpClient.PutAsJsonAsync($"adventures/{id}", adventure);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAdventureAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"adventures/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

}
