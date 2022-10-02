using QuestionService.Domain.ValueObjects;
using QuestionService.Repository.Models;
using Shouldly;

namespace QuestionService.Repository.Tests
{
    public class QueryableQuestionnaireEntityRepositoryTests
    {


        [Fact]

        public async Task GetQuestionairewtTitleAsync_ShouldReturnAQuestionanaireWhenExist()
        {

            //Arrange 
            var QuestionnaireTitle = "Geography Questions";
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
            var mockRepo = MockQuestionnaireRepository.GetQuestionareMockRepo().Object;
            //Act
            var result = await mockRepo.GetQuestionairewtTitleAsync(QuestionnaireTitle, CancellationToken.None);

            //Assert

            Assert.NotNull(result);
            result.IsSuccess.ShouldBeTrue();
            result.Success.ShouldBeEquivalentTo(_questionaireEntities);
        }
    }
}
