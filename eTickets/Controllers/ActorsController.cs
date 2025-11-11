using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {

        private readonly IActorService _service;  // Creating instance of the interface 


        public ActorsController(IActorService service) // Passing the value to the object through a Constructor
        {
            _service = service;

        }

        public async Task<IActionResult> Index(string searchString)
        {

            var data = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                data = data.Where(a => a.FullName.ToLower().Contains(searchString.ToLower())).ToList();

            }

            return View(data);
        }



        public IActionResult Create()
        {
            return View();


        }

        [HttpPost]
        public IActionResult Create([Bind("ProfilePicUrl,FullName,Bio")] Actor act)  // Through this Bind We bind only the properties that we are gonna send from the Post Request.
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(act);
            //}

            _service.AddAsync(act);
            return RedirectToAction(nameof(Index));

        }

        // For getting the details of the actor by ID , Maybe for implementing search feature 
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null)
            {
                return View("Empty");

            }

            return View(actorDetails);






        }



        public async Task<IActionResult> Edit(int id)
        {


            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("Empty");
            }
            else return View(actorDetails);



        }



        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePicUrl,FullName,Bio")] Actor act)  // Through this Bind We bind only the properties that we are gonna send from the Post Request.
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            await _service.UpdateAsync(id, act);
            return RedirectToAction(nameof(Index));

        }



        // Deleting a Record :

        public async Task<IActionResult> Delete(int id)
        {


            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("Empty");
            }
            else return View(actorDetails);



        }



        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)  // Through this Bind We bind only the properties that we are gonna send from the Post Request.
        {   var actorDetails = await _service.GetByIdAsync(id);


            if (actorDetails == null) return View("Empty");


            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }
    }
}
