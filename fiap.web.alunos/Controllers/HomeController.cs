using System.Diagnostics;
using fiap.web.alunos.Data;
using fiap.web.alunos.Logging;
using fiap.web.alunos.Models;
using Microsoft.AspNetCore.Mvc;

namespace fiap.web.alunos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomLogger _customLogger;
        private readonly DatabaseContext _databaseContext;
        public HomeController(DatabaseContext databaseContext, ICustomLogger customLogger)
        {
            _databaseContext = databaseContext;
            _customLogger = customLogger;
        }

        public IActionResult Index()
        {
            _customLogger.Log("Fiap");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
