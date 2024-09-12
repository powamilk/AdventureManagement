using AdventureManagement.API.Entities;
using AdventureManagement.API.ViewModel.ParticipantInteraction;

namespace AdventureManagement.API.Service.Interface
{
    public interface IParticipantInteractionService
    {
        Task<List<ParticipantInteractionVM>> GetAllParticipantInteractionsAsync();
        Task<ParticipantInteractionVM> GetParticipantInteractionByIdAsync(int id);
        Task CreateParticipantInteractionAsync(CreateParticipantInteractionVM model);
        Task UpdateParticipantInteractionAsync(int id, UpdateParticipantInteractionVM model);
        Task DeleteParticipantInteractionAsync(int id);
    }

}
