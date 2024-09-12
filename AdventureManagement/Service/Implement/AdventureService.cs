using AdventureManagement.API.Entities;
using AdventureManagement.API.Service.Interface;
using AdventureManagement.API.ViewModel.AdventureVM;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdventureManagement.API.Service.Implement
{
    public class AdventureService : IAdventureService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AdventureService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AdventureVM>> GetAllAdventuresAsync()
        {
            var adventures = await _context.Adventures.Include(a => a.Guide).Include(a => a.ParticipantInteractions).ToListAsync();
            return _mapper.Map<List<AdventureVM>>(adventures);
        }

        public async Task<AdventureVM> GetAdventureByIdAsync(int id)
        {
            var adventure = await _context.Adventures.Include(a => a.Guide)
                .Include(a => a.ParticipantInteractions).FirstOrDefaultAsync(a => a.Id == id);
            if (adventure == null) return null;

            return _mapper.Map<AdventureVM>(adventure);
        }

        public async Task CreateAdventureAsync(CreateAdventureVM model)
        {
            var adventure = new Adventure
            {
                Title = model.Title,
                Description = model.Description,
                Location = model.Location,
                Duration = model.Duration,
                GuideId = model.GuideId
            };

            _context.Adventures.Add(adventure);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdventureAsync(int id, UpdateAdventureVM model)
        {
            var adventure = await _context.Adventures.FindAsync(id);
            if (adventure == null) return;

            adventure.Title = model.Title;
            adventure.Description = model.Description;
            adventure.Location = model.Location;
            adventure.Duration = model.Duration;
            adventure.GuideId = model.GuideId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdventureAsync(int id)
        {
            var adventure = await _context.Adventures.FindAsync(id);
            if (adventure != null)
            {
                _context.Adventures.Remove(adventure);
                await _context.SaveChangesAsync();
            }
        }
    }

}
