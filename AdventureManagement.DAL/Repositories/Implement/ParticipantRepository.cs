using AdventureManagement.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureManagement.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdventureManagement.DAL.Repositories.Implement
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly AppDbContext _context;

        public ParticipantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Participant>> GetAllAsync()
        {
            return await _context.Participants.ToListAsync();
        }

        public async Task<Participant> GetByIdAsync(int id)
        {
            return await _context.Participants.FindAsync(id);
        }

        public async Task<bool> AddAsync(Participant participant)
        {
            _context.Participants.Add(participant);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Participant participant)
        {
            _context.Participants.Update(participant);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            if (participant == null) return false;
            _context.Participants.Remove(participant);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
