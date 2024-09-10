using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class TrainManager : ITrainService
    {
        private readonly IRepositoryManager _repositoryManager;

        public TrainManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Train>> GetAllTrainsAsync()
        {
            return await _repositoryManager.Train.GetAllTrainsAsync();
        }

        public async Task<Train> GetTrainByIdAsync(int id)
        {
            return await _repositoryManager.Train.GetTrainByIdAsync(id);
        }

        public async Task AddTrainAsync(Train train)
        {
            await _repositoryManager.Train.AddTrainAsync(train);
        }

        public async Task UpdateTrainAsync(Train train)
        {
            await _repositoryManager.Train.UpdateTrainAsync(train);
        }

        public async Task DeleteTrainAsync(Train train)
        {
            await _repositoryManager.Train.DeleteTrainAsync(train);
        }
    }
}
