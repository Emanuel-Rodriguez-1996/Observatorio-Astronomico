using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAppFront_end.Filter
{
    public class Admin : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("rol") != "Administrador")
                // no tiene persmiso para ver esta seccion
                context.Result = new RedirectToActionResult("Index", "Usuario", null);
        }
    }
}
