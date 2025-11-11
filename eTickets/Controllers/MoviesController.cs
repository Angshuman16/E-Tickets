using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {

      // private readonly  AppDbContext _context;


        private readonly IMoviesService _service;


        public MoviesController(IMoviesService service)
        {
            _service = service;
            
        }





        public async Task< IActionResult> Index(string searchString)
        
        {
            var data = await _service.GetAllAsyncWithIncludes(m => m.Cinema);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                data = data.Where(m =>
                            (!string.IsNullOrEmpty(m.Name) &&
                             m.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                         || (m.Cinema != null && !string.IsNullOrEmpty(m.Cinema.Name) &&
                             m.Cinema.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                       )
                       .ToList();
            }

            return View(data);



            //var data = await _service.GetAllAsyncWithIncludes(m => m.Cinema);

            //if (!string.IsNullOrEmpty(searchString))
            //{

            //    data = data.Where(a => a.Name.ToLower().Contains(searchString.ToLower())).ToList();
            //}




            //return View(data);
        }
    }
}
