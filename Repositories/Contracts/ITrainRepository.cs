using Entities.Models;

namespace Repositories.Contracts
{
    public interface ITrainRepository : IRepositoryBase<Train>
    {
        Task AddTrainAsync(Train train); 
        Task UpdateTrainAsync(Train train);
        Task DeleteTrainAsync(Train train);
        Task<IEnumerable<Train>> GetAllTrains();
        Task<Train> GetTrainByIdAsync(int id);

    }
}
