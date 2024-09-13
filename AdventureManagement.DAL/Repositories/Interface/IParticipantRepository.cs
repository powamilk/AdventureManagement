using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureManagement.DAL.Entities;

namespace AdventureManagement.DAL.Repositories.Interface
{
    public interface IParticipantRepository : IRepository<Participant>
    {
        Task<List<Participant>> GetAllAsync();
        Task<Participant> GetByIdAsync(int id);
        Task<bool> AddAsync(Participant participant);
        Task<bool> UpdateAsync(Participant participant);
        Task<bool> DeleteAsync(int id);
    }
}
