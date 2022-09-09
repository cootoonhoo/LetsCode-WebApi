using Microsoft.AspNetCore.Mvc.Filters;
namespace CadastroCliente.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        //Lidar com a parte de model
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Console.WriteLine("Filtro de Ação -> {ANTES} OnActionExecuting ");
        }
    }
}
