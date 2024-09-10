using Entities.Models;

namespace Services.Contracts
{
    public interface ITrainService
    {
        Task<IEnumerable<Train>> GetAllTrainsAsync();
        Task<Train> GetTrainByIdAsync(int id);
        Task AddTrainAsync(Train train);
        Task UpdateTrainAsync(Train train);
        Task DeleteTrainAsync(Train train);
    }
}
