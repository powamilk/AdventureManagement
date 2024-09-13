using AdventureManagement.DAL.Entities;
using AdventureManagement.BUS.Service.Interface;
using AdventureManagement.BUS.ViewModel.OrganismViewModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdventureManagement.BUS.Service.Implement
{
    public class OrganismService : IOrganismService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrganismService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrganismVM>> GetAllOrganismsAsync()
        {
            var organisms = await _context.Organisms
                .Include(o => o.AdventureOrganisms)
                    .ThenInclude(ao => ao.Adventure)
                .ToListAsync();

            return _mapper.Map<List<OrganismVM>>(organisms);
        }

        public async Task<OrganismVM> GetOrganismByIdAsync(int id)
        {
            var organism = await _context.Organisms
                .Include(o => o.AdventureOrganisms)
                    .ThenInclude(ao => ao.Adventure)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (organism == null) return null;

            return _mapper.Map<OrganismVM>(organism);
        }

        public async Task CreateOrganismAsync(CreateOrganismVM model)
        {
            var organism = new Organism
            {
                Name = model.Name,
                Description = model.Description,
                Habitat = model.Habitat
            };

            _context.Organisms.Add(organism);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrganismAsync(int id, UpdateOrganismVM model)
        {
            var organism = await _context.Organisms.FindAsync(id);
            if (organism == null) return;

            organism.Name = model.Name;
            organism.Description = model.Description;
            organism.Habitat = model.Habitat;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrganismAsync(int id)
        {
            var organism = await _context.Organisms.FindAsync(id);
            if (organism != null)
            {
                _context.Organisms.Remove(organism);
                await _context.SaveChangesAsync();
            }
        }
    }


}
