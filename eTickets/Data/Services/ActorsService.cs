using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorService
    {

        //Now in order to get the values from the database we need  to implement a constructor and able to insert te appdbContext  

        private readonly AppDbContext _context;


        // Now, We can get the acces of the database from here and  WE CAN now implement the remaining functions using this context 
        public ActorsService(AppDbContext context)
        {


            _context = context; 

            //Is this Dependency Injection????

             //-->>
        }




        public void Add(Actor actor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public  async Task<IEnumerable<Actor>> GetAllActors()
        {
            var result =  await _context.Actors.ToListAsync();
            return result;
        }

        public Actor GetById(int id)
        {

          

            throw new NotImplementedException();
        }

        public Actor Update(int id, Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
