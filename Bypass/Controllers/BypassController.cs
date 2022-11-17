using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Bypass.Data.Interfaces;
using Bypass.Data.Types;
using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Bypass.Controllers
{
    [Route("bypass")]
    [Authorize]
    public class BypassController : Controller
    {
        IBypassItems _bypass;
        IArchiveModel _archiveModel;
        IEditModel _editModel;

        public BypassController(IConfiguration config, 
            IBypassItems bypass, 
            IArchiveModel archiveMdel,
            IEditModel editModel
            )
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
            _editModel = editModel;
            _editModel.SetConfiguration(con);
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
                DateFrom = DateTime.Now.Date.AddYears(-3).ToString("dd.MM.yyyy"),
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

        [HttpGet]
        [Route("/getbypass")]
        public IActionResult GetBypass()
        {
            var items = _bypass.GetAllItems();
            return Ok(items);
        }

        [HttpGet]
        [Route("/bypassedit")]
        public IActionResult BypassEdit()
        {
            return View();
        }

        [HttpGet]
        [Route("/api/spremploee")]
        public async Task<IActionResult> SprEmployee()
        {
            var rez = _editModel.SprEmployee();
            return Ok(rez);
        }

        [HttpGet]
        [Route("/api/sprevents")]
        public async Task<IActionResult> SprEvents()
        {
            var rez = _editModel.SprEvents();
            return Ok(rez);
        }

        [HttpGet]
        [Route("/api/sprprops")]
        public async Task<IActionResult> SprProps()
        {
            var rez = _editModel.SprProps("");
            return Ok(rez);
        }

        [HttpGet]
        [Route("/api/bypass")]
        public async Task<IActionResult> GetBypass(string id)
        {
            var rez = _editModel.GetBypass(id);
            return Ok(rez);
        }
    }
}
