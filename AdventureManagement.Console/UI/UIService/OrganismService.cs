using AdventureManagementConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AdventureManagementConsole.UI.UIService
{
    public class OrganismService
    {
        private readonly HttpClient _httpClient;

        public OrganismService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7191/api/");
        }

        public async Task<List<OrganismModel>> GetAllOrganismsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<OrganismModel>>("organisms");
        }

        public async Task CreateOrganismAsync(object organism)
        {
            var response = await _httpClient.PostAsJsonAsync("organisms", organism);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateOrganismAsync(int id, object organism)
        {
            var response = await _httpClient.PutAsJsonAsync($"organisms/{id}", organism);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteOrganismAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"organisms/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

}
