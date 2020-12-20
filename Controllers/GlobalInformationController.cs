using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using regalo_web.ViewModels;

namespace regalo_web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GlobalInformationController : ControllerBase
    {
        private readonly ILogger<GlobalInformationController> _logger;
        private readonly IConfiguration _configuration;

        public GlobalInformationController(IConfiguration configuration, ILogger<GlobalInformationController> logger)
        {
            this._logger = logger;
            this._configuration = configuration;
        }

        [HttpGet]
        public async Task<GlobalInformationModel> GetAsync()
        {
            GlobalInformationModel global = null;
            
            await Task.Run(() =>  
                global = new GlobalInformationModel
                {
                    TargetFolder = this._configuration["AppSettings:Target"]
                }
            );

            return global;
        }
    }
}
