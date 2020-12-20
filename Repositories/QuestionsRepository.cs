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
                        Question = "Come si chiama l'artista?",
                        ImagUrl = "arte.jpg",
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
                        Question = "Chi abita in questa fonte?",
                        ImagUrl = "mojenca.jpg",
                        Options = new List<string> {
                            "Un tritone",
                            "Un drago",
                            "Un guru"
                        },
                        Answers = new List<string> {
                            GlobalConstants.CorrectAnswer,
                            "Magari!",
                            "Forse lo era, ma restiamo pragmatici per adesso"
                        }
                    },
                    new QuestionModel {
                        Question = "Dove è stata scattata questa foto?",
                        ImagUrl = "trio.jpg",
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
                }},
                { GlobalConstants.Mirella, new List<QuestionModel> {
                    new QuestionModel {
                        Question = "Domanda 1?",
                        ImagUrl = "arte.jpg",
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
                        Question = "Domanda 2?",
                        ImagUrl = "mojenca.jpg",
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
                        Question = "Domanda 3?",
                        ImagUrl = "trio.jpg",
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