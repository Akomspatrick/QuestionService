using Microsoft.AspNetCore.Mvc;
using QuestionService.Repository;
using QuestionService.Repository.Models;
using Railway;

namespace QuestionService
{
    public class ResultAction : IActionResult
    {

        public Result<QuestionnaireEntity, QueryableQuestionEntityFailure> Value { get; set; }

        public int? StatusCode { get; set; } 
        object response = null;
        public ResultAction(Result<QuestionnaireEntity, QueryableQuestionEntityFailure> value)
        {
            this.Value = value;
            

            object Code = null;
            if (Value.IsSuccess)
            {
                response = Value.Success.MapToSuccessResponse();
                Code = 200;
                this.StatusCode = 200;
            }
            else
            {
                Code = 404;
                response = "Not Found";
                this.StatusCode = 404;
            }

        }



        public async Task ExecuteResultAsync(ActionContext context)
        {
            
            var objectResult = new ObjectResult(this.response)
            {
                StatusCode = this.StatusCode
            };
          //  this.StatusCode= objectResult.StatusCode;
            await objectResult.ExecuteResultAsync(context);
           // this.StatusCode = objectResult.StatusCode;
        }

    }
}
