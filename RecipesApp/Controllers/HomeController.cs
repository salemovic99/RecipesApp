using Microsoft.AspNetCore.Mvc;
using RecipesApp.Models;
using RecipesApp.Servcises;
using System.Diagnostics;

namespace RecipesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepcipeService repcipeService;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient, IRepcipeService repcipeService)
        {
            _logger = logger;
            this.repcipeService = repcipeService;
        }

        public async Task<IActionResult> Index()
        {
            if (!InternetConnectionChecker.IsInternetAvailable())
            {
                return View("ErrorConnection");
            }

            var recipes = await repcipeService.getRecipes();
            return View(recipes);
        }



        public async Task<IActionResult> Details(int id)
        {
            try
            {
                Recipe recipe = await repcipeService.getRecipesById(id);
                if (recipe == null)
                    return NotFound();

                return View(recipe);
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }

        public IActionResult ErrorConnection()
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