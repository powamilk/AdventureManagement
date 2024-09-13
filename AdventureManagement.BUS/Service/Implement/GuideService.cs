using AdventureManagement.DAL.Entities;
using AdventureManagement.BUS.Service.Interface;
using AdventureManagement.BUS.ViewModel.GuideViewModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdventureManagement.BUS.Service.Implement
{
    public class GuideService : IGuideService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GuideService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GuideVM>> GetAllGuidesAsync()
        {
            var guides = await _context.Guides.Include(g => g.Adventures).ToListAsync();
            return _mapper.Map<List<GuideVM>>(guides);
        }

        public async Task<GuideVM> GetGuideByIdAsync(int id)
        {
            var guide = await _context.Guides.Include(g => g.Adventures).FirstOrDefaultAsync(g => g.Id == id);
            if (guide == null) return null;

            return _mapper.Map<GuideVM>(guide);
        }

        public async Task CreateGuideAsync(CreateGuideVM model)
        {
            var guide = new Guide
            {
                Name = model.Name,
                Expertise = model.Expertise,
                ExperienceYears = model.ExperienceYears
            };

            _context.Guides.Add(guide);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGuideAsync(int id, UpdateGuideVM model)
        {
            var guide = await _context.Guides.FindAsync(id);
            if (guide == null) return;

            guide.Name = model.Name;
            guide.Expertise = model.Expertise;
            guide.ExperienceYears = model.ExperienceYears;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteGuideAsync(int id)
        {
            var guide = await _context.Guides.FindAsync(id);
            if (guide != null)
            {
                _context.Guides.Remove(guide);
                await _context.SaveChangesAsync();
            }
        }
    }

}
