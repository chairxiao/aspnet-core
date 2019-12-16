using Microsoft.AspNetCore.Antiforgery;
using TestUse.Controllers;

namespace TestUse.Web.Host.Controllers
{
    public class AntiForgeryController : TestUseControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
