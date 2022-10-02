using QuestionService.Application.Handlers;
using QuestionService.Application.Queries;
using QuestionService.Repository.Tests;
using Shouldly;

namespace QuestionService.Application.Test
{
    public class GetQuestionnairewtTitleHandlerTests
    {





        [Fact]
        public async Task GetQuestionnairewtTitleHandler_ShouldOneReturn_QuestionaireWhenCalled()
        {
            var mockRepo = MockQuestionnaireRepository.GetQuestionareMockRepo();
            var handler = new GetQuestionnairewtTitleHandler(mockRepo.Object);
            var QuestionnaireTitle = "Geography Questions";
            var result = await handler.Handle(new GetQuestionnairewtTitleQuery() { questionnaireTitle = QuestionnaireTitle }, CancellationToken.None);
            result.ShouldNotBeNull();

            Assert.NotNull(result);
            result.IsSuccess.ShouldBeTrue();

        }
    }
}
