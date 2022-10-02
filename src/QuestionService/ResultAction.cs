using Microsoft.AspNetCore.Mvc;
using QuestionService.Repository;
using QuestionService.Repository.Models;
using Railway;

namespace QuestionService
{
    public class ResultAction : IActionResult
    {

        public Result<QuestionnaireEntity, QueryableQuestionEntityFailure> Value { get; set; }



        public ResultAction(Result<QuestionnaireEntity, QueryableQuestionEntityFailure> value)
        {
            this.Value = value;
        }



        public async Task ExecuteResultAsync(ActionContext context)
        {
            object response = null;

            object Code = null;
            if (Value.IsSuccess)
            {
                response = Value.Success.MapToSuccessResponse();
                Code = 200;

            }
            else
            {
                Code = 404;
                response = "Not Found";
            }

            var objectResult = new ObjectResult(response)
            {
                StatusCode = (int)Code
            };

            await objectResult.ExecuteResultAsync(context);
        }

    }
}
