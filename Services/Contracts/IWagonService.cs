using Entities.Models;

namespace Services.Contracts
{
    public interface IWagonService
    {
        Task<IEnumerable<Wagon>> GetAllWagonsAsync();
        Task<Wagon> GetWagonByIdAsync(int id);
        Task AddWagonAsync(Wagon wagon);
        Task UpdateWagonAsync(Wagon wagon);
        Task DeleteWagonAsync(Wagon wagon);
    }
}
