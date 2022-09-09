using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data.SqlClient;

namespace CadastroCliente.Filters
{
    public class GeneralExcpetionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var problemDetail = new ProblemDetails {
                Status = 500,
                Title = "Erro inpesperado",
                Detail = "Ocorreu um erro inesperado na solcitação",
                Type = context.Exception.GetType().Name
            };
            Console.WriteLine("EXCEÇÃO:");
            Console.WriteLine($"Tipo da EXCEÇÃO: {context.Exception.GetType().Name} \n");
            Console.WriteLine($"Menssagem -> {context.Exception.Message} \n");
            Console.WriteLine($"Stacktree -> {context.Exception.StackTrace}  \n");
            Console.WriteLine();

            switch (context.Exception)
            {
                case SqlException:
                    problemDetail.Status = 503;
                    problemDetail.Title = "Erro com o banco de dados";
                    problemDetail.Detail = "Tente novamente mais tarde, ou contate o suporte";
                    context.HttpContext.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                    context.Result = new ObjectResult(problemDetail);
                    break;
                case NullReferenceException:
                    problemDetail.Status = 417;
                    problemDetail.Title = "Erro inesperado no sistema";
                    context.HttpContext.Response.StatusCode = StatusCodes.Status417ExpectationFailed;
                    context.Result = new ObjectResult(problemDetail);
                    break;
                default:
                    problemDetail.Status = 500;
                    problemDetail.Title = "Erro inesperado. Tente novamente";
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Result = new ObjectResult(problemDetail);
                    break;
            }
        }
    }
}
