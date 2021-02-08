using Microsoft.AspNetCore.Mvc;
using Web.Communication;
using System.Linq;

namespace Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected bool ResponseHasErrors(ResponseResult result)
        {
            if (result != null && result.Errors.Any())
            {
                foreach (var message in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, message);
                }

                return true;
            }

            return false;
        }

        protected void CreateErroValidation(string message)
        {
            ModelState.AddModelError(string.Empty, message);
        }

        protected bool ValidOperation()
        {
            return ModelState.ErrorCount == 0;
        }
    }
}
