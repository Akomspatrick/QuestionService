using Moq;
using QuestionService.Application.Commands;
using QuestionService.Application.Handlers;
using QuestionService.Repository.Tests;
using Shouldly;

namespace QuestionService.Application.Test
{
    public class AddAnswerCommandHandlerTest
    {

        [Fact]
        public async Task AddAnswerCommandHandler_ShouldSubmitAnswer_WhenCalled()
        {
            var mockRepo = MockAnswerRepository.GetAnswerMockRepo();
            var handler = new AddAnswerCommandHandler(mockRepo.Object);

            var result = await handler.Handle(new AddAnswerCommand(It.IsAny<string>(), It.IsAny<List<string>>()), CancellationToken.None);
            result.ShouldNotBeNull();

            Assert.NotNull(result);
            result.IsSuccess.ShouldBeTrue();

        }
    }
}
