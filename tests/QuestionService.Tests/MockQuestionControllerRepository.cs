using MediatR;
using Moq;
using QuestionService.Application.Queries;
using QuestionService.Domain.ValueObjects;
using QuestionService.Repository;
using QuestionService.Repository.Models;
using Railway;

namespace QuestionService.Tests
{
    public static class MockQuestionControllerRepository
    {
        public static Mock<ISender> GetQuestionareControllerMockRepo()
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
            var mockRepo = new Mock<ISender>();
            var QuestionnaireTitle = "Geography Questions";
            mockRepo.Setup(x => x.Send(new GetQuestionnairewtTitleQuery() { questionnaireTitle = QuestionnaireTitle }, CancellationToken.None)).
                ReturnsAsync(
                    new Result<QuestionnaireEntity, QueryableQuestionEntityFailure>(_questionaireEntities));


            return mockRepo;





        }
    }
}
