using QuestionService.Domain.ValueObjects;
using QuestionService.Repository.Interfaces;
using QuestionService.Repository.Models;
using Railway;

namespace QuestionService.Repository
{
    public class QueryableQuestionnaireEntityRepository : IQueryableQuestionEntityRepository
    {
        private readonly IEnumerable<QuestionnaireEntity> _questionaireEntities;

        public QueryableQuestionnaireEntityRepository()
        {
            _questionaireEntities = new List<QuestionnaireEntity>
            {
                new QuestionnaireEntity {
                    questionnaireTitle ="Geography Questions", questionText= new List<Question>
                                                                                 {
                                                                                    new Question { AQuestion ="What is the capital of Italy?"},
                                                                                    new Question { AQuestion ="What is the capital of France?"},
                                                                                    new Question { AQuestion ="What is the capital of Uk?"},
                                                                                    new Question { AQuestion ="What is the capital of Germany?"},


                                                                                  }
                }
            };
        }


        public async Task<Result<QuestionnaireEntity, QueryableQuestionEntityFailure>> GetQuestionairewtTitleAsync(string questionnaireTitle, CancellationToken cancellationToken)
        {
            ///The assumtion here is that the questionnaireTitle is the key to the datasource
            ///  and the datasource returns either zero or 1 Questionaire
            var questionaire = await Task.FromResult(_questionaireEntities.Where(x => x.questionnaireTitle == questionnaireTitle).ToList());
            if (questionaire.Count == 0) return QueryableQuestionEntityFailure.NotFoundInRepository;

            return new Result<QuestionnaireEntity, QueryableQuestionEntityFailure>(questionaire.First());
        }

    }
}
