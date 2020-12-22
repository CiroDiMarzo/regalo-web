using System.Collections.Generic;
using regalo_web.ViewModels;
using regalo_web.Constants;
using System;

namespace regalo_web.Repositories
{
    public interface IQuestionsRepository
    {
        List<QuestionModel> GetQuestions(string key);
    }

    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly Dictionary<string, List<QuestionModel>> _data;

        public QuestionsRepository()
        {
            this._data = new Dictionary<string, List<QuestionModel>> {
                { GlobalConstants.Daniela, new List<QuestionModel> {
                    new QuestionModel {
                        Id = 1,
                        Question = "In quale università insegna l'artista?",
                        ImageUrl = "arte.jpg",
                        Options = new List<OptionModel> {
                            new OptionModel { Id = 1, Title = "Della Potenza" },
                            new OptionModel { Id = 2, Title = "Della Bellezza" },
                            new OptionModel { Id = 3, Title = "Della Calvizia" }
                        },
                        Answers = new List<AnswerModel> {
                            new AnswerModel { OptionId = 1, QuestionId = 1, Title = "Ne ha da condividere...però no" },
                            new AnswerModel { OptionId = 2, QuestionId = 1, Title = GlobalConstants.CorrectAnswer, IsCorrect = true },
                            new AnswerModel { OptionId = 3, QuestionId = 1, Title = "Potrei essere interessato! Ma no." }
                        }
                    },
                    new QuestionModel {
                        Id = 2,
                        Question = "Dove è stata scattata questa foto?",
                        ImageUrl = "trio.jpg",
                        Options = new List<OptionModel> {
                            new OptionModel { Id = 4, Title = "In Sud Africa" },
                            new OptionModel { Id = 5, Title = "A Roncobilaccio" },
                            new OptionModel { Id = 6, Title = "In India" }
                        },
                        Answers = new List<AnswerModel> {
                            new AnswerModel { OptionId = 4, QuestionId = 2, Title = GlobalConstants.CorrectAnswer, IsCorrect = true },
                            new AnswerModel { OptionId = 5, QuestionId = 2, Title = "eh? O_o" },
                            new AnswerModel { OptionId = 6, QuestionId = 2, Title = "No, ma era come se lo fosse..." }
                        }
                    },
                    new QuestionModel {
                        Id = 3,
                        Question = "Chi abita in questa fonte?",
                        ImageUrl = "mojenca.jpg",
                        Options = new List<OptionModel>{
                            new OptionModel { Id = 7, Title = "Un tritone" },
                            new OptionModel { Id = 8, Title = "Un drago" },
                            new OptionModel { Id = 9, Title = "Un guru" }
                        },
                        Answers = new List<AnswerModel> {
                            new AnswerModel { OptionId = 7, QuestionId = 3, Title = GlobalConstants.CorrectAnswer, IsCorrect = true },
                            new AnswerModel { OptionId = 8, QuestionId = 3, Title = "Magari!" },
                            new AnswerModel { OptionId = 9, QuestionId = 3, Title = "Anche, ma restiamo pragmatici...PER ADESSO" }
                        }
                    }
                }}
            };
        }

        public List<QuestionModel> GetQuestions(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException(nameof(key));
            }

            if (!this._data.ContainsKey(key))
            {
                throw new ArgumentException($"The key is not present in the data dictionary {key}");
            }

            return this._data[key];
        }
    }
}