using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {

       

        private readonly IProducerService _service;



        public ProducersController(IProducerService service)
        {
            _service = service;

        }


        public async Task<IActionResult> Index()
        {

            var allProduceers = await _service.GetAllAsync();
            return View(allProduceers);
        }


        public IActionResult Create()
        {
            return View();


        }

        [HttpPost]
        public IActionResult Create([Bind("profilepicUrl,fullName,Bio")] Producer Prod)  // Through this Bind We bind only the properties that we are gonna send from the Post Request.
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(act);
            //}

            _service.AddAsync(Prod);
            return RedirectToAction(nameof(Index));

        }


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
        public async Task<IActionResult> Edit(int id, [Bind("Id,profilepicUrl,fullName,Bio")] Producer Prod)  // Through this Bind We bind only the properties that we are gonna send from the Post Request.
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            await _service.UpdateAsync(id, Prod);
            return RedirectToAction(nameof(Index));

        }


        // Deleting a record of Producer

        public async Task<IActionResult> Delete(int id)
        {


            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null)
            {
                return View("Empty");
            }
            else return View(producerDetails);



        }



        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)  // Through this Bind We bind only the properties that we are gonna send from the Post Request.
        {
            var producerDetails = await _service.GetByIdAsync(id);


            if (producerDetails == null) return View("Empty");


            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }







    }
}
