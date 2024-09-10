
namespace Services.Contracts
{
    public interface IServiceManager
    {
        ITrainService TrainManager { get; }
        IWagonService WagonManager { get; }
    }
}
