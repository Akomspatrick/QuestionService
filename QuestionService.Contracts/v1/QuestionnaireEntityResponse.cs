namespace QuestionService.Contracts.v1
{
    public class QuestionnaireEntityResponse
    {
        public string questionnaireTitle { get; set; } = String.Empty;

        public IEnumerable<string> questionText { get; set; } = Array.Empty<string>();

    }
}
