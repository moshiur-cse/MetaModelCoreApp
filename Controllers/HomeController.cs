using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MetaModelCoreApp.Models;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;

namespace MetaModelCoreApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly metamodel_db_testContext _context;

        public HomeController(metamodel_db_testContext context)
        {
            _context = context;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{

        //    return View();
        //}

        public async Task<IActionResult> Index(int? filter, int pageIndex = 1, string sortExpression = "RunCode")
        {

            ViewBag.Senario = _context.Senarios.ToList();
            ViewBag.Strategy = _context.Strategies.ToList();
            ViewBag.Goals = _context.BdpGoals.ToList();
            
            var qry = _context.CropLoss.Take(100);

            if (filter != null)
            {
                qry = qry.Where(p => p.RunCode == filter);
            }

            var model = await PagingList.CreateAsync(qry,10,pageIndex, sortExpression, "RunCode");

            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);

            //return View(await pdbDbContext.ToListAsync());
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MapView()
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
