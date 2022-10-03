using Moq;
using QuestionService.Domain.ValueObjects;
using QuestionService.Repository.Interfaces;
using QuestionService.Repository.Models;
using Railway;

namespace QuestionService.Repository.Tests
{
    public static class MockQuestionnaireRepository
    {

        public static Mock<IQueryableQuestionEntityRepository> GetQuestionareMockRepo()
        {
            var _questionaireEntities =
              new QuestionnaireEntity
              {
                  questionnaireTitle = "Geography Questions",
                  questionText = new List<Question>
                                                                                 {
                                                                                    new Question { AQuestion ="What is the capital of Italy?"},
                                                                                    new Question { AQuestion ="What is the capital of France?"},
                                                                                    new Question { AQuestion ="What is the capital of Uk?"},
                                                                                    new Question { AQuestion ="What is the capital of Germany?"},


                                                                                  }

              };
            var mockRepo = new Mock<IQueryableQuestionEntityRepository>();
            var QuestionnaireTitle = "Geography Questions";



            mockRepo.Setup(x => x.GetQuestionairewtTitleAsync(QuestionnaireTitle, CancellationToken.None)).ReturnsAsync(

                new Result<QuestionnaireEntity, QueryableQuestionEntityFailure>(_questionaireEntities));

            return mockRepo;


        }
    }
}
