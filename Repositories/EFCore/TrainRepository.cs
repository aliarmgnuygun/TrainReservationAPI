
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

        public async Task<IEnumerable<Train>> GetAllTrainsAsync()
        {
            return await _context.Trains
                .Include(t => t.Wagons)
                .ToListAsync();
        }

        public async Task<Train> GetTrainByIdAsync(int id) 
        {
            return await _context.Trains
                 .Include(t => t.Wagons) 
                 .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateTrainAsync(Train train)
        {
            _context.Trains.Update(train);
            await _context.SaveChangesAsync(); 
        }
    }
}
