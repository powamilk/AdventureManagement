using AdventureManagement.API.Entities;
using AdventureManagement.API.Service.Interface;
using AdventureManagement.API.ViewModel.OrganismVM;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdventureManagement.API.Service.Implement
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
            var organisms = await _context.Organisms.ToListAsync();

            var organismVMs = organisms.Select(o => new OrganismVM
            {
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                Habitat = o.Habitat,
                AdventureCount = _context.Adventures.Count(a => a.Description.Contains(o.Name)) // Giả định các sinh vật được nhắc đến trong Description
            }).ToList();

            return organismVMs;
        }

        public async Task<OrganismVM> GetOrganismByIdAsync(int id)
        {
            var organism = await _context.Organisms.FindAsync(id);
            if (organism == null) return null;

            var organismVM = new OrganismVM
            {
                Id = organism.Id,
                Name = organism.Name,
                Description = organism.Description,
                Habitat = organism.Habitat,
                AdventureCount = await _context.Adventures.CountAsync(a => a.Description.Contains(organism.Name)) // Tương tự
            };

            return organismVM;
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
