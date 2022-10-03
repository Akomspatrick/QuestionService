using Moq;
using QuestionService.Repository.Interfaces;
using QuestionService.Repository.Models;
using Railway;

namespace QuestionService.Repository.Tests
{
    public static class MockAnswerRepository
    {
        public static Mock<IQueryableAnswerEntityRepository> GetAnswerMockRepo()
        {

            var mockRepo = new Mock<IQueryableAnswerEntityRepository>();
            var ans = new AnswerEntity { questionnaireTitle = "New Geograty", selectedAnswers = new List<string> { "UK", "US" } };

            mockRepo.Setup(x => x.PostAnswerAsync(It.IsAny<AnswerEntity>(), CancellationToken.None)).ReturnsAsync(
                           new Result<AnswerEntity, QueryableQuestionEntityFailure>(ans));


            return mockRepo;
        }
    }
}
