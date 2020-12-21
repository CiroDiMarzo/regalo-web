namespace regalo_web.ViewModels
{
    public class AnswerModel    {
        public int QuestionId { get; set; }

        public int OptionId { get; set; }

        public string Title { get; set; }

        public bool IsCorrect { get; set; }
    }
}