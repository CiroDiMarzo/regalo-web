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
                        Options = new List<string> {
                            "Della Saggezza",
                            "Della Bellezza",
                            "Della Calvizia"
                        },
                        Answers = new List<string> {
                            "Ne ha da condividere...però no",
                            GlobalConstants.CorrectAnswer,
                            "Potrei essere interessato! Ma no."
                        }
                    },
                    new QuestionModel {
                        Id = 2,
                        Question = "Dove è stata scattata questa foto?",
                        ImageUrl = "trio.jpg",
                        Options = new List<string> {
                            "In Sud Africa",
                            "A Pollena Trocchia",
                            "In India"
                        },
                        Answers = new List<string> {
                            GlobalConstants.CorrectAnswer,
                            "eh? O_o",
                            "No, ma era come se lo fosse..."
                        }
                    },
                    new QuestionModel {
                        Id = 3,
                        Question = "Chi abita in questa fonte?",
                        ImageUrl = "mojenca.jpg",
                        Options = new List<string> {
                            "Un tritone",
                            "Un drago",
                            "Un guru"
                        },
                        Answers = new List<string> {
                            GlobalConstants.CorrectAnswer,
                            "Magari!",
                            "Anche, ma restiamo pragmatici...PER ADESSO"
                        }
                    }
                }},
                { GlobalConstants.Mirella, new List<QuestionModel> {
                    new QuestionModel {
                        Id = 4,
                        Question = "Domanda 1?",
                        ImageUrl = "arte.jpg",
                        Options = new List<string> {
                            "Fabrizio",
                            "Patrizio",
                            "Pancrazio"
                        },
                        Answers = new List<string> {
                            "Ogni tanto veniva chiamato cosi...ma no",
                            GlobalConstants.CorrectAnswer,
                            "ahah. no."
                        }
                    },
                    new QuestionModel {
                        Id = 5,
                        Question = "Domanda 2?",
                        ImageUrl = "mojenca.jpg",
                        Options = new List<string> {
                            "Un tritone",
                            "Un drago",
                            "Un guru"
                        },
                        Answers = new List<string> {
                            GlobalConstants.CorrectAnswer,
                            "Magari!",
                            "Forse...ma restiamo pragmatici adesso"
                        }
                    },
                    new QuestionModel {
                        Id = 6,
                        Question = "Domanda 3?",
                        ImageUrl = "trio.jpg",
                        Options = new List<string> {
                            "In Sud Africa",
                            "A Pollena Trocchia",
                            "In India"
                        },
                        Answers = new List<string> {
                            GlobalConstants.CorrectAnswer,
                            "eh?",
                            "No, ma era come se lo fosse..."
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