using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using regalo_web.ViewModels;

namespace regalo_web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly ILogger<ConfigurationController> _logger;
        private readonly IConfiguration _configuration;

        public ConfigurationController(IConfiguration configuration,
            ILogger<ConfigurationController> logger)
        {
            this._logger = logger;
            this._configuration = configuration;
        }

        [HttpGet]
        public async Task<ConfigurationModel> GetAsync()
        {
            ConfigurationModel configuration = null;
            
            await Task.Run(() => {
                configuration = new ConfigurationModel { TargetFolder = this._configuration["AppSettings:Target"] };
            });

            return configuration;
        }
    }
}
