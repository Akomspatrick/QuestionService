using MediatR;
using QuestionService.Repository;
using QuestionService.Repository.Models;
using Railway;

namespace QuestionService.Application.Commands
{
    public record AddAnswerCommand(string Title, IEnumerable<string> Answer) : IRequest<Result<AnswerEntity, QueryableQuestionEntityFailure>>;

}
