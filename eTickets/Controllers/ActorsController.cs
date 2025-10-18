using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {

        private readonly IActorService _service;  // Creating instance of the interface 


        public ActorsController(IActorService service) // Passing the value to the object through a Constructor
        {
            _service = service;

        }

        public async Task<IActionResult> Index()
        {

            var data = await _service.GetAllActors();

            return View(data); 
        }



        public IActionResult Create()
        {
            return View();


        }

        [HttpPost]
        public IActionResult Create([Bind("ProfilePicUrl,FullName,Bio")] Actor act)  // Through this Bind We bind only the properties that we are gonna send from the Post Request.
        {
            if (!ModelState.IsValid)
            {
                return View(act);
            }

            _service.Add(act);
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Details(int id)
        {
            var actorDetails =  _service.GetById(id);

            if(actorDetails == null) {
                return View("Empty");

        }

            return View(actorDetails);






    }
}
