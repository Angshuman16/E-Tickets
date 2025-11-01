using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
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


        public IActionResult Create()
        {
            return View();


        }

        [HttpPost]
        public IActionResult Create([Bind("Logo,Name,Description")] Cinema cinema)  // Through this Bind We bind only the properties that we are gonna send from the Post Request.
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(act);
            //}

            _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetByIdAsync(id);

            if (cinemaDetails == null)
            {
                return View("Empty");

            }

            return View(cinemaDetails);






        }


        public async Task<IActionResult> Edit(int id)
        {


            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("Empty");
            }
            else return View(cinemaDetails);



        }



        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)  // Through this Bind We bind only the properties that we are gonna send from the Post Request.
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));

        }



        public async Task<IActionResult> Delete(int id)
        {


            var cinemaDetails = await _service.GetByIdAsync(id);
            if (cinemaDetails == null)
            {
                return View("Empty");
            }
            else return View(cinemaDetails);



        }



        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)  // Through this Bind We bind only the properties that we are gonna send from the Post Request.
        {
            var cinemaDetails = await _service.GetByIdAsync(id);


            if (cinemaDetails == null) return View("Empty");


            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }










    }
}
