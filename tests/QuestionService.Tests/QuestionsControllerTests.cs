using System.Security.Cryptography.X509Certificates;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using QuestionService.Application.Queries;
using QuestionService.Contracts.v1;
using QuestionService.Controllers.v1;
using QuestionService.Domain.ValueObjects;
using QuestionService.Repository;
using QuestionService.Repository.Models;
using Railway;
using Shouldly;

namespace QuestionService.Tests
{
    public class QuestionsControllerTests
    {
        private readonly QuestionsController _sut;
        private readonly Mock<ISender> _senderMock;
        public QuestionsControllerTests()
        {
            _senderMock = new Mock<ISender>();
            _sut = new QuestionsController(_senderMock.Object);

        }

        [Fact]
        public async Task Get_Action_ShouldNotFoundInRepository_WhenQuestionNaireTitleDoesNotExist()
        {

            _senderMock.Setup(x => x.Send(It.IsAny<GetQuestionnairewtTitleQuery>(), It.IsAny<CancellationToken>())).
                ReturnsAsync(
                    new Result<QuestionnaireEntity, QueryableQuestionEntityFailure>(QueryableQuestionEntityFailure.NotFoundInRepository)
                    );
            var result = (ResultAction)await _sut.Get(It.IsAny<string>(), CancellationToken.None);
            //Assert
            var x = result.Value;
            result.Value.Failures.ShouldContain(QueryableQuestionEntityFailure.NotFoundInRepository); 
          
        }


        [Fact]
        public async Task Get_Action_ShouldReturnStatusCode404_WhenQuestionNaireTitleDoesNotExist()
        {

            _senderMock.Setup(x => x.Send(It.IsAny<GetQuestionnairewtTitleQuery>(), It.IsAny<CancellationToken>())).
                ReturnsAsync(
                    new Result<QuestionnaireEntity, QueryableQuestionEntityFailure>(QueryableQuestionEntityFailure.NotFoundInRepository)
                    );
            var result = (ResultAction)await _sut.Get(It.IsAny<string>(), CancellationToken.None);
            //Assert
            result.StatusCode.ShouldBe(404);

        }


        [Fact]
        public async Task Get_Action_ShouldResultAction_WhenUserExist()
        {
            //arrange
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
            var questionnaireTitle = "Geography Questions";

            _senderMock.Setup(x => x.Send(It.IsAny<GetQuestionnairewtTitleQuery>(), It.IsAny<CancellationToken>())).
                ReturnsAsync(
                    new Result<QuestionnaireEntity, QueryableQuestionEntityFailure>(_questionaireEntities)
                    );
            //Act
            var result = (ResultAction)await _sut.Get(questionnaireTitle, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
           result.StatusCode.ShouldBe(200);

        }


        [Fact]
        public async Task Get_Action_ShouldContainOnequestionnaireTitle_WhenUserExist()
        {
            //arrange
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
            var questionnaireTitle = "Geography Questions";

            _senderMock.Setup(x => x.Send(It.IsAny<GetQuestionnairewtTitleQuery>(), It.IsAny<CancellationToken>())).
                ReturnsAsync(
                    new Result<QuestionnaireEntity, QueryableQuestionEntityFailure>(_questionaireEntities)
                    );
            //Act

            var result = (ResultAction)await _sut.Get(questionnaireTitle, CancellationToken.None);
            //Assert
            //       
            var obj = result.Value.Success;

            obj.ShouldBeEquivalentTo(_questionaireEntities);


        }

    }
}
