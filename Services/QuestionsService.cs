using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using regalo_web.Constants;
using regalo_web.Repositories;
using regalo_web.ViewModels;

namespace regalo_web.Services
{
    public interface IQuestionsService
    {
        AnswerResultModel GetAnswer(string key, int index, int answerIndex);
        ValidationResult ValidateAnswers(string key, AnswerModel[] answers);
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

        public AnswerResultModel GetAnswer(string key, int questionId, int optionId)
        {
            List<QuestionModel> questions = this._questionsRepository.GetQuestions(key);

            QuestionModel question = questions.FirstOrDefault(q => q.Id == questionId);

            bool isCorrect = false;

            AnswerModel answer = question.Answers.FirstOrDefault(a => a.QuestionId == questionId && a.OptionId == optionId);
            
            if (answer.Title == GlobalConstants.CorrectAnswer)
            {
                isCorrect = true;
            }

            return new AnswerResultModel
            {
                IsCorrect = isCorrect,
                Message = answer.Title
            };
        }

        public ValidationResult ValidateAnswers(string key, AnswerModel[] answers)
        {
            List<QuestionModel> questions = this._questionsRepository.GetQuestions(key);

            ValidationResult result = new ValidationResult{ IsValid = true };

            foreach (QuestionModel question in questions)
            {
                AnswerModel givenAnswer = answers.FirstOrDefault(a => a.QuestionId == question.Id);

                if (givenAnswer == null)
                {
                    result.IsValid = false;
                    result.Message = "Manca una risposta! Eh no eh!";

                    break;
                }

                AnswerModel answer = question.Answers.FirstOrDefault(a => a.OptionId == givenAnswer.OptionId);

                if (!answer.IsCorrect)
                {
                    result.IsValid = false;
                    result.Message = "Eh no, una risposta è sbagliata";

                    break;
                }
            }

            return result;
        }
    }
}