using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly ITrainService _trainService;
        private readonly IWagonService _wagonService;

        public ServiceManager(ITrainService trainManager, IWagonService wagonManager)
        {
            _trainService = trainManager;
            _wagonService = wagonManager;
        }

        public ITrainService TrainManager => _trainService;

        public IWagonService WagonManager => _wagonService;
    }
}
