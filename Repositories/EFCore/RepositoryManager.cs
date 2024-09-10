using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly ITrainRepository _trainRepository;
        private readonly IWagonRepository _wagonRepository;

        public RepositoryManager(RepositoryContext repositoryContext, ITrainRepository trainRepository, IWagonRepository wagonRepository)
        {
            _repositoryContext = repositoryContext;
            _trainRepository = trainRepository;
            _wagonRepository = wagonRepository;
        }

        public ITrainRepository Train => _trainRepository;

        public IWagonRepository Wagon => _wagonRepository;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }

}
