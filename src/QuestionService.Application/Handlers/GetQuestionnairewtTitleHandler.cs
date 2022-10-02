using MediatR;
using QuestionService.Application.Queries;
using QuestionService.Repository;
using QuestionService.Repository.Interfaces;
using QuestionService.Repository.Models;
using Railway;

namespace QuestionService.Application.Handlers
{
    /// <summary>
    /// todo change this from QueryableQuestionEntityFailure to error from the domain ==>GetQuestionnaireEntityFailure and map it appropriately later 
    /// </summary>
    public class GetQuestionnairewtTitleHandler : IRequestHandler<GetQuestionnairewtTitleQuery, Result<QuestionnaireEntity, QueryableQuestionEntityFailure>>
    {
        private readonly IQueryableQuestionEntityRepository _queryableQuestionEntityRepository;

        public GetQuestionnairewtTitleHandler(IQueryableQuestionEntityRepository queryableQuestionEntityRepository)
        {
            _queryableQuestionEntityRepository = queryableQuestionEntityRepository;
        }
        public async Task<Result<QuestionnaireEntity, QueryableQuestionEntityFailure>> Handle(GetQuestionnairewtTitleQuery request, CancellationToken cancellationToken)
        {
            var result = await _queryableQuestionEntityRepository.GetQuestionairewtTitleAsync(request.questionnaireTitle, cancellationToken);
            return result;
        }
    }
}



