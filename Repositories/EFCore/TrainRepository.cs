
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class TrainRepository : RepositoryBase<Train>, ITrainRepository
    {
        public TrainRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task AddTrainAsync(Train train)
        {
            await _context.Trains.AddAsync(train);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrainAsync(Train train)
        {
            _context.Trains.Remove(train);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Train>> GetAllTrains()
        {
            return await _context.Trains.ToListAsync();
        }

        public async Task<Train> GetTrainByIdAsync(int id) => await _context.Trains.FindAsync(id);

        public async Task UpdateTrainAsync(Train train)
        {
            _context.Trains.Update(train);
            await _context.SaveChangesAsync(); 
        }
    }
}
