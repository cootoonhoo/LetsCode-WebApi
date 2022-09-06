using Microsoft.AspNetCore.Mvc.Filters;

namespace CadastroClientes.Filters
{
    public class LogAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine("Filtro de autorização OnAuthorization");
        }
    }
}
