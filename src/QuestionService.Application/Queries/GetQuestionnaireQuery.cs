using MediatR;
using QuestionService.Repository;
using QuestionService.Repository.Models;
using Railway;

namespace QuestionService.Application.Queries
{
    public record GetQuestionnaireQuery : IRequest<Result<QuestionnaireEntity, QueryableQuestionEntityFailure>>
    {

    }
}
