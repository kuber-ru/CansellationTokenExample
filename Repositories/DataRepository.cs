namespace CansellationTokenExample.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly ILogger<DataRepository> _logger;

        public DataRepository(ILogger<DataRepository> logger)
        {
            _logger = logger;
        }

        public async Task<int> GetDataAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Start");

            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000, cancellationToken);
                _logger.LogInformation($"{i} из 10 Step");
            }

            _logger.LogInformation("Stop");

            return 0;
        }
    }

    public interface IDataRepository
    {
        Task<int> GetDataAsync(CancellationToken cancellationToken = default);
    }
}
