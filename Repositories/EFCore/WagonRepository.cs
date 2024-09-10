using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class WagonRepository : RepositoryBase<Wagon>, IWagonRepository
    {
        public WagonRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task AddWagonAsync(Wagon wagon)
        {
            await _context.Wagons.AddAsync(wagon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWagonAsync(Wagon wagon)
        {
            _context.Wagons.Remove(wagon);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Wagon>> GetAllWagons()
        {
            return await _context.Wagons.ToListAsync();
        }

        public async Task<Wagon> GetWagonByIdAsync(int id)
        {
            return await _context.Wagons.FindAsync(id);
        }

        public async Task UpdateWagonAsync(Wagon wagon)
        {
            _context.Wagons.Update(wagon);
            await _context.SaveChangesAsync();
        }
    }
}
