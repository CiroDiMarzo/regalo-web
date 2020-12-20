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
    public class QuestionsController : ControllerBase
    {
        private readonly ILogger<QuestionsController> _logger;
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IConfiguration _configuration;

        public QuestionsController(IConfiguration configuration,
            ILogger<QuestionsController> logger,
            IQuestionsRepository questionsRepository)
        {
            this._logger = logger;
            this._questionsRepository = questionsRepository;
            this._configuration = configuration;
        }

        [HttpGet]
        public async Task<List<QuestionModel>> GetAsync()
        {
            List<QuestionModel> questions = null;
            
            await Task.Run(() =>  
                questions = this._questionsRepository.GetQuestions(this._configuration["AppSettings:Target"])
            );

            return questions;
        }
    }
}
