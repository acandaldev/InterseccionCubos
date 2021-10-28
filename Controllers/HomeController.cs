using InterseccionCubos.Models;
using InterseccionCubos.Models.Cube;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InterseccionCubos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new CubeModel());
        }
        public IActionResult Calcular(CubeModel model)
        {
          
            Cube cuboA = CubeFactory.Cube().CenteredAt(model.XCubeA, model.YCubeA, model.ZCubeA).WithEdgeLength(model.lengthCubeA).Build();
            Cube cuboB = CubeFactory.Cube().CenteredAt(model.XCubeB, model.YCubeB, model.ZCubeB).WithEdgeLength(model.lengthCubeB).Build();
            model.Resultado = cuboA.IntersectionVolumeWith(cuboB);
            ModelState.Clear();
            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
