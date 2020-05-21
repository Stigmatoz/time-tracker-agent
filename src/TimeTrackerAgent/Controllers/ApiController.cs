using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimeTrackerAgent.DTO;
using TimeTrackerAgent.Storage.Repository;

namespace TimeTrackerAgent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly IStorageRepository _storage;

        public ApiController(ILogger<ApiController> logger, IStorageRepository storage)
        {
            _logger = logger;
            _storage = storage;
        }

        [HttpGet]
        public async Task<IActionResult> GetOverallInfo()
        {
            var day = await _storage.GetCurrentDayAsync();
            return Ok(new DashboardInfo(day));
        }
    }
}
