using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace regalo_web.ViewModels
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Question { get; set; }
        public List<string> Options { get; set; }
        [JsonIgnore]
        public List<string> Answers { get; set; }
    }
}