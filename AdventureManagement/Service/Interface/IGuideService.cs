using AdventureManagement.API.ViewModel.GuideViewModel;

namespace AdventureManagement.API.Service.Interface
{
    public interface IGuideService
    {
        Task<List<GuideVM>> GetAllGuidesAsync();
        Task<GuideVM> GetGuideByIdAsync(int id);
        Task CreateGuideAsync(CreateGuideVM model);
        Task UpdateGuideAsync(int id, UpdateGuideVM model);
        Task DeleteGuideAsync(int id);
    }

}
