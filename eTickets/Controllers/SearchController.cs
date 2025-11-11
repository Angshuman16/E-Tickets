using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class SearchController : Controller
    {


        private readonly ICinemaService _cinemaService;
        private readonly IProducerService _producerService;
        private readonly IActorService _actorService;


        public SearchController(ICinemaService cinemaService, IProducerService producerService, IActorService actorService)
        {

            _cinemaService = cinemaService;
            _producerService = producerService;
            _actorService = actorService;

            
        }

        public async Task<IActionResult> Index(string searchString)
        {

            if (string.IsNullOrEmpty(searchString))
            {

                return RedirectToAction("Index", "Movies");  // Actually raeturning to the Home Page


            }

            


            return View();
        }
    }
}
