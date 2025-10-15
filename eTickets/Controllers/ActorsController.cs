using eTickets.Data;
using eTickets.Data.Services;
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



    }
}
