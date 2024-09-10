using Entities.Models;

namespace Repositories.Contracts
{
    public interface ITrainRepository : IRepositoryBase<Train>
    {
        Task<IEnumerable<Train>> GetAllTrainsAsync();
        Task<Train> GetTrainByIdAsync(int id);
        Task AddTrainAsync(Train train);
        Task UpdateTrainAsync(Train train);
        Task DeleteTrainAsync(Train train);

    }
}
