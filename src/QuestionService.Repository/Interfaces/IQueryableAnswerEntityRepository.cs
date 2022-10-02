using QuestionService.Repository.Models;
using Railway;

namespace QuestionService.Repository.Interfaces
{
    public interface IQueryableAnswerEntityRepository
    {
        Task<Result<AnswerEntity, QueryableQuestionEntityFailure>> PostAnswerAsync(AnswerEntity entity, CancellationToken cancellationToken);
    }
}
