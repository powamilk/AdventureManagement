using AdventureManagement.BUS.ViewModel.Participant;

namespace AdventureManagement.BUS.Service.Interface
{
    public interface IParticipantService
    {
        Task<List<ParticipantVM>> GetAll();
        Task<ParticipantVM> GetById(int id);
        Task<bool> Create(ParticipantCreateVM model);
        Task<bool> Update(int id, ParticipantUpdateVM model);
        Task<bool> Delete(int id);
    }

}
