using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class WagonManager : IWagonService
    {
        private readonly IRepositoryManager _repositoryManager;

        public WagonManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<IEnumerable<Wagon>> GetAllWagonsAsync()
        {
            return await _repositoryManager.Wagon.GetAllWagons();
        }

        public async Task<Wagon> GetWagonByIdAsync(int id)
        {
            return await _repositoryManager.Wagon.GetWagonByIdAsync(id);
        }

        public async Task AddWagonAsync(Wagon wagon)
        {
            await _repositoryManager.Wagon.AddWagonAsync(wagon);
        }

        public async Task UpdateWagonAsync(Wagon wagon)
        {
            await _repositoryManager.Wagon.UpdateWagonAsync(wagon);
        }

        public async Task DeleteWagonAsync(Wagon wagon)
        {
            await _repositoryManager.Wagon.DeleteWagonAsync(wagon);
        }
    }
}
