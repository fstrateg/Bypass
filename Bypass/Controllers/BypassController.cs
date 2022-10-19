using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Bypass.Data.Mocks;
using Bypass.Data.Interfaces;

namespace Bypass.Controllers
{
    [Route("bypass")]
    [ApiController]
    [Authorize]
    public class BypassController : Controller
    {
        IBypassItems _bypass;

        public BypassController(IBypassItems bypass)
        {
            _bypass = bypass;
        }

        [Route("/")]
        public IActionResult Index()
        {
            var items=_bypass.GetAllItems();
            return View(items);
        }

        [Route("/archive")]
        public IActionResult Archive()
        {
            return View();
        }
    }
}
