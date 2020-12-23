using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using regalo_web.Repositories;
using regalo_web.ViewModels;
using regalo_web.Services;

namespace regalo_web.Controllers
{
    [ApiController]
    [Route("gi")]
    public class GiftController : ControllerBase
    {
        private readonly ILogger<GiftController> _logger;
        private readonly IGiftRepository _giftRepository;
        private readonly IQuestionsService _questionsService;
        private readonly IConfiguration _configuration;

        public GiftController(IConfiguration configuration,
            ILogger<GiftController> logger,
            IGiftRepository questionsRepository,
            IQuestionsService questionsService)
        {
            this._logger = logger;
            this._giftRepository = questionsRepository;
            this._questionsService = questionsService;
            this._configuration = configuration;
        }

        [HttpPost]
        public async Task<ValidationResult> GetAsync([FromBody] AnswerModel[] answers)
        {
            ValidationResult validationResult = this._questionsService.ValidateAnswers(this._configuration["AppSettings:Target"], answers);

            if (validationResult.IsValid)
            {
                await Task.Run(() =>  
                    validationResult.GiftList = this._giftRepository.GetGift(this._configuration["AppSettings:Target"])
                );
            }

            return validationResult;
        }
    }
}
