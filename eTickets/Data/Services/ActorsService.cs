using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorService
    {

        //Now in order to get the values from the database we need  to implement a constructor and able to insert te appdbContext  

       


        // Now, We can get the acces of the database from here and  WE CAN now implement the remaining functions using this context 
        public ActorsService(AppDbContext context) : base(context) { }
       




       

    }
}
