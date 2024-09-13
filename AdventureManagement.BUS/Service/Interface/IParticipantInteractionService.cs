using AdventureManagement.DAL.Entities;
using AdventureManagement.BUS.ViewModel.ParticipantInteraction;

namespace AdventureManagement.BUS.Service.Interface
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
