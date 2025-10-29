using eTickets.Data;
using eTickets.Data.Services;
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
    }
}
