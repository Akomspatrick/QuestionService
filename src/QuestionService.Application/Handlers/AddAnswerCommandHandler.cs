using MediatR;
using QuestionService.Application.Commands;
using QuestionService.Repository;
using QuestionService.Repository.Interfaces;
using QuestionService.Repository.Models;
using Railway;

namespace QuestionService.Application.Handlers
{
    public class AddAnswerCommandHandler : IRequestHandler<AddAnswerCommand, Result<AnswerEntity, QueryableQuestionEntityFailure>>
    {
        private readonly IQueryableAnswerEntityRepository _queryableAnswerEntityRepository;

        public AddAnswerCommandHandler(IQueryableAnswerEntityRepository queryableAnswerEntityRepository)
        {
            _queryableAnswerEntityRepository = queryableAnswerEntityRepository;
        }
        public Task<Result<AnswerEntity, QueryableQuestionEntityFailure>> Handle(AddAnswerCommand request, CancellationToken cancellationToken)
        {
            return _queryableAnswerEntityRepository.PostAnswerAsync(new AnswerEntity { questionnaireTitle = request.Title, selectedAnswers = request.Answer }, cancellationToken);
        }
    }
}
