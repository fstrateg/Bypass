using Bypass.Data.Models;
using Bypass.Models;
using Bypass.Models.Types;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bypass.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private Connect connect;
        public UserController(IConfiguration config)
        {
            connect = new Connect()
            {
                UserName = config.GetConnectionString("UserName"),
                Password = config.GetConnectionString("Password"),
                DataSource = config.GetConnectionString("DataSource")
            };
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromForm] LoginModel model)
        {
            if (!model.Validate())
            {
                ViewBag.ErrorMessage = model.LastError;
                return View(model);
            }
            ModelDb modelDb=new ModelDb(connect);
            if (!modelDb.CheckUser(model.User,model.Password))
            {
                ViewBag.ErrorMessage = "Пользователь не найден или не верный пароль!";
                return View(model);
            }
            var Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Alex")
            };
            var Identify=new ClaimsIdentity(Claims, "MyAuthCookie");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(Identify);
            HttpContext.SignInAsync(claimsPrincipal);
            return RedirectToAction("Index","Bypass");
        }

        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
