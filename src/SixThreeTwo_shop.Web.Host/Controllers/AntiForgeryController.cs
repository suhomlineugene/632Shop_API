using Abp.Web.Security.AntiForgery;
using SixThreeTwo_shop.Controllers;
using Microsoft.AspNetCore.Antiforgery;

namespace SixThreeTwo_shop.Web.Host.Controllers
{
    public class AntiForgeryController : SixThreeTwo_shopControllerBase
    {
        private readonly IAntiforgery _antiforgery;
        private readonly IAbpAntiForgeryManager _antiForgeryManager;

        public AntiForgeryController(IAntiforgery antiforgery, IAbpAntiForgeryManager antiForgeryManager)
        {
            _antiforgery = antiforgery;
            _antiForgeryManager = antiForgeryManager;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }

        public void SetCookie()
        {
            _antiForgeryManager.SetCookie(HttpContext);
        }
    }
}
