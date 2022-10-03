using FunctionalTools;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuestionService.Application.Commands;
using QuestionService.Application.Queries;
using QuestionService.Repository;
using QuestionService.Repository.Models;
using Railway;

namespace QuestionService.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {

        private readonly ISender _sender;


        public QuestionsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AnswerEntity answer)
        {
            var model = new AddAnswerCommand(answer.questionnaireTitle, answer.selectedAnswers);
            var result = await _sender.Send(model);
            if (result.IsSuccess)
            {
                return Ok(result.Success);
            }
            return Ok(result.Failures);
        }


        [HttpGet]
        public async Task<IActionResult> Get(string questionnaireTitle, CancellationToken cancellationToken)
        {
            var IdQuestionTitle = await questionnaireTitle.EnsureInputIsNotNull(QueryableQuestionEntityFailure.NotFoundInRepository).AsAsync().// Bind(_ => SendGe(questionnaireTitle, cancellationToken));
              Bind(_ => SendGetQuestionairewtTitleQuery(questionnaireTitle, cancellationToken)).Result.AsAsync();

            //Delevelop Binding and Mapping for the pipeline later
            var result = await _sender.Send(new GetQuestionnairewtTitleQuery { questionnaireTitle = questionnaireTitle }, cancellationToken);

            return new ResultAction(IdQuestionTitle);

        }


        private async Task<Result<QuestionnaireEntity, QueryableQuestionEntityFailure>> SendGetQuestionairewtTitleQuery(string questionnaireTitle, CancellationToken cancellationToken)
        {
            return await _sender.Send(new GetQuestionnairewtTitleQuery { questionnaireTitle = questionnaireTitle }).MapFailure(failure =>
            failure switch
            {
                QueryableQuestionEntityFailure.NotFoundInRepository => QueryableQuestionEntityFailure.NotFoundInRepository,
                _ => throw new Exception("Planned to log this ")
            });
        }


    }
}
