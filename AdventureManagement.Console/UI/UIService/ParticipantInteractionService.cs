using AdventureManagementConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AdventureManagementConsole.UI.UIService
{
    public class ParticipantInteractionService
    {
        private readonly HttpClient _httpClient;

        public ParticipantInteractionService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7191/api/");
        }

        public async Task<List<ParticipantInteractionModel>> GetAllParticipantInteractionsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ParticipantInteractionModel>>("participant-interactions");
        }

        public async Task CreateParticipantInteractionAsync(CreateParticipantInteractionModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("participant-interactions", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateParticipantInteractionAsync(int id, UpdateParticipantInteractionModel model)
        {
            var response = await _httpClient.PutAsJsonAsync($"participant-interactions/{id}", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteParticipantInteractionAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"participant-interactions/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
