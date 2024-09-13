using AdventureManagement.BUS.ViewModel.AdventureViewModel;

namespace AdventureManagement.BUS.Service.Interface
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
