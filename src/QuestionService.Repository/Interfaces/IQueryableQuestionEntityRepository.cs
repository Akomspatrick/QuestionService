using QuestionService.Repository.Models;
using Railway;

namespace QuestionService.Repository.Interfaces
{
    public interface IQueryableQuestionEntityRepository
    {
        Task<Result<QuestionnaireEntity, QueryableQuestionEntityFailure>> GetQuestionairewtTitleAsync(string questionnaireTitle, CancellationToken cancellationToken);



    }
}
