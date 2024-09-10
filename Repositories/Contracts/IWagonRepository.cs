using Entities.Models;

namespace Repositories.Contracts
{
    public interface IWagonRepository : IRepositoryBase<Wagon>
    {
        Task AddWagonAsync(Wagon wagon); 
        Task UpdateWagonAsync(Wagon wagon); 
        Task DeleteWagonAsync(Wagon wagon);
        Task<IEnumerable<Wagon>> GetAllWagons();
        Task<Wagon> GetWagonByIdAsync(int id); 

    }
}
