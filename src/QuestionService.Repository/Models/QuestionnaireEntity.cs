using QuestionService.Contracts.v1;
using QuestionService.Domain.ValueObjects;
namespace QuestionService.Repository.Models
{
    public class QuestionnaireEntity
    {
        public string questionnaireTitle { get; set; }

        //public    IEnumerable< Question> QuestionText  { get; set; }
        public IEnumerable<Question> questionText { get; set; }

        public QuestionnaireEntityResponse MapToSuccessResponse()
        {
            var response = new QuestionnaireEntityResponse()
            {
                questionnaireTitle = this.questionnaireTitle,
                questionText = this.questionText.Select(x => x.AQuestion)
            };
            return response;
        }
    }

}

