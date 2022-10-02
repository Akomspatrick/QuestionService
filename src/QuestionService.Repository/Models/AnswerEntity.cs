namespace QuestionService.Repository.Models
{
    public class AnswerEntity
    {
        public string questionnaireTitle { get; set; }

        //public    IEnumerable< Question> QuestionText  { get; set; }
        public IEnumerable<string> selectedAnswers { get; set; }
    }
}
