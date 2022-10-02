using MediatR;
using QuestionService.Repository;
using QuestionService.Repository.Models;
using Railway;

namespace QuestionService.Application.Queries
{
    public class GetQuestionnairewtTitleQuery : IRequest<Result<QuestionnaireEntity, QueryableQuestionEntityFailure>>
    {
        public string questionnaireTitle { get; init; }
    }
}
