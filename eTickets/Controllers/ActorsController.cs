using eTickets.Data;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {

        private readonly AppDbContext _context;  // Creating an Instance of the class AppDbContext


        public ActorsController(AppDbContext context) // Passing the value to the object through a Constructor
        {
            _context = context;

        }

        public IActionResult Index()
        {
            
            var data = _context.Actors.ToList();
            return View(data); 
        }




    }
}
