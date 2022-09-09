using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CadastroCliente.Filters
{
    public class LogAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.Keys.Contains("Id")) {
                context.HttpContext.Request.Headers.Add("Id", Guid.NewGuid().ToString());
            }
            Console.WriteLine($"UID da LOG -> {context.HttpContext.Request.Headers["Id"]}");
            Console.WriteLine("AUTHORIZATION FILTER : Dentro da OnAuthorization ");
        }
    }
}
