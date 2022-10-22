using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Bypass.Data.Mocks;
using Bypass.Data.Interfaces;
using Bypass.Data.Types;
using System;

namespace Bypass.Controllers
{
    [Route("bypass")]
    [Authorize]
    public class BypassController : Controller
    {
        IBypassItems _bypass;
        IArchiveModel _archiveModel;

        public BypassController(IBypassItems bypass, IArchiveModel archiveMdel)
        {
            _bypass = bypass;
            _archiveModel = archiveMdel;
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
    }
}
