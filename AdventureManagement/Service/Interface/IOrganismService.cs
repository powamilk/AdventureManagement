using AdventureManagement.API.ViewModel.OrganismVM;

namespace AdventureManagement.API.Service.Interface
{
    public interface IOrganismService
    {
        Task<List<OrganismVM>> GetAllOrganismsAsync();
        Task<OrganismVM> GetOrganismByIdAsync(int id);
        Task CreateOrganismAsync(CreateOrganismVM model);
        Task UpdateOrganismAsync(int id, UpdateOrganismVM model);
        Task DeleteOrganismAsync(int id);
    }

}
