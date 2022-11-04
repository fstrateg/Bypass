using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Bypass.Data.Mocks;
using Bypass.Data.Interfaces;
using Bypass.Data.Types;
using System;
using Microsoft.Extensions.Configuration;
using Bypass.Models.Types;

namespace Bypass.Controllers
{
    [Route("bypass")]
    [Authorize]
    public class BypassController : Controller
    {
        IBypassItems _bypass;
        IArchiveModel _archiveModel;

        public BypassController(IConfiguration config, IBypassItems bypass, IArchiveModel archiveMdel)
        {
            Connect con = new Connect()
            {
                UserName = config.GetConnectionString("UserName"),
                Password = config.GetConnectionString("Password"),
                DataSource = config.GetConnectionString("DataSource")
            };
            _bypass = bypass;
            _bypass.SetConfiguration(con);
            _archiveModel = archiveMdel;
            _archiveModel.SetConfiguration(con);
        }

        [Route("/")]
        public IActionResult Index()
        {
            var items=_bypass.GetAllItems();
            return View(items);
        }

        [HttpGet]
        [Route("/archive")]
        public IActionResult Archive()
        {
            _archiveModel.Filter = new ArchiveForm()
            {
                DateTo = DateTime.Now.Date.ToString("dd.MM.yyyy"),
                DateFrom = DateTime.Now.Date.AddMonths(-1).ToString("dd.MM.yyyy"),
                Fio = ""
            };
            return View(_archiveModel);
        }

        [HttpPost]
        [Route("/archive")]
        public IActionResult Archive([FromForm] ArchiveForm filter)
        {
            _archiveModel.Filter = filter;
            _archiveModel.Fetch();
            return View(_archiveModel);
        }

        [HttpPost]
        [Route("/archivedata")]
        public IActionResult ArchiveData([FromForm] ArchiveForm filter)
        {
            _archiveModel.Filter = filter;
            _archiveModel.Fetch();
            return Ok(_archiveModel.Data);
        }
    }
}
