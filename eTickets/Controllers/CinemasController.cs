using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {


        public readonly AppDbContext _context;


        public readonly ICinemaService _service;


        public CinemasController(ICinemaService service)
        {
            _service = service;

        }



        public async Task<IActionResult>Index()
        {

            var allCinemas = await _service.GetAllAsync();
            return View(allCinemas);
        }
    }
}
