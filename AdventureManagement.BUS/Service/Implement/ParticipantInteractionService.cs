using AdventureManagement.DAL.Entities;
using AdventureManagement.BUS.Service.Interface;
using AdventureManagement.BUS.ViewModel.ParticipantInteraction;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdventureManagement.BUS.Service.Implement
{
    public class ParticipantInteractionService : IParticipantInteractionService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ParticipantInteractionService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ParticipantInteractionVM>> GetAllParticipantInteractionsAsync()
        {
            var interactions = await _context.ParticipantInteractions
                .Include(p => p.Adventure)
                .Include(p => p.Participant)
                .ToListAsync();

            return _mapper.Map<List<ParticipantInteractionVM>>(interactions);
        }

        public async Task<ParticipantInteractionVM> GetParticipantInteractionByIdAsync(int id)
        {
            var interaction = await _context.ParticipantInteractions
                .Include(p => p.Adventure)
                .Include(p => p.Participant)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (interaction == null)
                return null;

            return _mapper.Map<ParticipantInteractionVM>(interaction);
        }

        public async Task CreateParticipantInteractionAsync(CreateParticipantInteractionVM model)
        {
            var interaction = new ParticipantInteraction
            {
                AdventureId = model.AdventureId,
                ParticipantId = model.ParticipantId,
                Rating = model.Rating,
                Comment = model.Comment,
                CreatedAt = DateTime.UtcNow
            };

            _context.ParticipantInteractions.Add(interaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateParticipantInteractionAsync(int id, UpdateParticipantInteractionVM model)
        {
            var interaction = await _context.ParticipantInteractions.FindAsync(id);
            if (interaction == null)
                return;

            interaction.Rating = model.Rating;
            interaction.Comment = model.Comment;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteParticipantInteractionAsync(int id)
        {
            var interaction = await _context.ParticipantInteractions.FindAsync(id);
            if (interaction != null)
            {
                _context.ParticipantInteractions.Remove(interaction);
                await _context.SaveChangesAsync();
            }
        }
    }

}
