using AdventureManagement.API.ViewModel.AdventureVM;

namespace AdventureManagement.API.Service.Interface
{
    public interface IAdventureService
    {
        Task<List<AdventureVM>> GetAllAdventuresAsync();
        Task<AdventureVM> GetAdventureByIdAsync(int id);
        Task CreateAdventureAsync(CreateAdventureVM model);
        Task UpdateAdventureAsync(int id, UpdateAdventureVM model);
        Task DeleteAdventureAsync(int id);
    }

}
