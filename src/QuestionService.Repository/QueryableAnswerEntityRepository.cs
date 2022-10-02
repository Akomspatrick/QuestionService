using QuestionService.Repository.Interfaces;
using QuestionService.Repository.Models;
using Railway;

namespace QuestionService.Repository
{
    public class QueryableAnswerEntityRepository : IQueryableAnswerEntityRepository
    {
        public static List<AnswerEntity> _answerDb = new();
        public async Task<Result<AnswerEntity, QueryableQuestionEntityFailure>> PostAnswerAsync(AnswerEntity entity, CancellationToken cancellationToken)
        {
            _answerDb.Add(entity);

            return await Task.FromResult(new Result<AnswerEntity, QueryableQuestionEntityFailure>(entity));
        }
    }
}
