using System.ComponentModel;

namespace QuestionService.Domain.Enumerations
{
    public enum GetQuestionnaireEntityFailure
    {
        [Description("UnKnown Error")]
        OtherProblemsThatIdontKnowNow,

        [Description("Questionnaire Title  Not  Found")]
        NotFoundInRepository


    }
}
