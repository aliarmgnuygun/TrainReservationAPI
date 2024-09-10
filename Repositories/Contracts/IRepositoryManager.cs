namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ITrainRepository Train { get; }
        IWagonRepository Wagon { get; }
        Task SaveAsync();
    }
}
