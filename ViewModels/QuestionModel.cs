using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace regalo_web.ViewModels
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Question { get; set; }
        public List<OptionModel> Options { get; set; }
        [JsonIgnore]
        public List<AnswerModel> Answers { get; set; }
    }
}