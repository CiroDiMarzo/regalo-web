using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using regalo_web.Constants;
using regalo_web.Repositories;
using regalo_web.ViewModels;

namespace regalo_web.Services
{
    public interface IQuestionsService
    {
        AnswerResultModel GetAnswer(string key, int index, int answerIndex);
    }

    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestionsRepository _questionsRepository;
        private readonly IConfiguration _configuration;

        public QuestionsService(IQuestionsRepository questionsRepository,
            IConfiguration configuration)
        {
            this._questionsRepository = questionsRepository;
            this._configuration = configuration;
        }

        public AnswerResultModel GetAnswer(string key, int index, int answerIndex)
        {
            List<QuestionModel> questions = this._questionsRepository.GetQuestions(key);

            QuestionModel question = questions[index];

            bool isCorrect = false;

            if (question.Answers[answerIndex] == GlobalConstants.CorrectAnswer)
            {
                isCorrect = true;
            }

            return new AnswerResultModel
            {
                IsCorrect = isCorrect,
                Message = question.Answers[answerIndex]
            };
        }
    }
}