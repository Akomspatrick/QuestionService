using QuestionService.Repository.Models;
using Shouldly;

namespace QuestionService.Repository.Tests
{
    public class QueryableAnswerEntityRepositoryTest
    {

        [Fact]
        public async Task PostAnswerAsync_ShouldReturnItemAdded()
        {

            var mockRepo = MockAnswerRepository.GetAnswerMockRepo().Object;
            //Act

            var ans = new AnswerEntity { questionnaireTitle = "New Geograty", selectedAnswers = new List<string> { "UK", "US" } };
            var result = await mockRepo.PostAnswerAsync(ans, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            result.IsSuccess.ShouldBeTrue();
            result.Success.ShouldBeEquivalentTo(ans);
            result.Success.ShouldBeOfType<AnswerEntity>();
        }
    }
}
