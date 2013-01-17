using System.Web.Mvc;

using ArtificialGold.Models.ViewModels;
using ArtificialGold.Services;

namespace ArtificialGold.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeViewModelRetriever _homeViewModelRetriever;

        public HomeController(IHomeViewModelRetriever homeViewModelRetriever)
        {
            _homeViewModelRetriever = homeViewModelRetriever;
        }

        public ViewResult Index()
        {
            HomeViewModel homeViewModel = _homeViewModelRetriever.GetModel();

            return View(homeViewModel);
        }
    }
}
