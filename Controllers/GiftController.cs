using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using regalo_web.Repositories;
using regalo_web.ViewModels;

namespace regalo_web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GiftController : ControllerBase
    {
        private readonly ILogger<GiftController> _logger;
        private readonly IGiftRepository _giftRepository;
        private readonly IConfiguration _configuration;

        public GiftController(IConfiguration configuration,
            ILogger<GiftController> logger,
            IGiftRepository questionsRepository)
        {
            this._logger = logger;
            this._giftRepository = questionsRepository;
            this._configuration = configuration;
        }

        [HttpGet]
        public async Task<List<GiftModel>> GetAsync()
        {
            List<GiftModel> giftList = null;
            
            await Task.Run(() =>  
                giftList = this._giftRepository.GetGift(this._configuration["AppSettings:Target"])
            );

            return giftList;
        }
    }
}
