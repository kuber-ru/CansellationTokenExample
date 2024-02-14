using CansellationTokenExample.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CansellationTokenExample.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ApiController : ControllerBase
    {

        private readonly ILogger<ApiController> _logger;
        private readonly IDataRepository _dataRepository;

        public ApiController(ILogger<ApiController> logger, IDataRepository dataRepository)
        {
            _logger = logger;
            _dataRepository = dataRepository;
        }


        [HttpGet]
        public async Task<int> GetWithOutCancellationToken()
        {
            return await _dataRepository.GetDataAsync(CancellationToken.None);
        }

        [HttpGet]
        public async Task<int> GetWithConcellationToken(CancellationToken cancellationToken)
        {
            return await _dataRepository.GetDataAsync(cancellationToken);
        }
    }
}
