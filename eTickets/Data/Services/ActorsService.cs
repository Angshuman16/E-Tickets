using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
           _context.Actors.Add(actor);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
        }

        public  async Task<IEnumerable<Actor>> GetAllActors()
        {
            var result =  await _context.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);  // It Returns an Actor object that matches the Id provided, This is using a lambda function to clarify if it matches with the given id or not
                                                                                      // 
            return result;

          

         
        }

        public async Task<Actor> UpdateAsync(int id, Actor actor)
        {
            var existingActor = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);

            if (existingActor == null)
            {
                return null; // Or throw an exception if you prefer
            }

            existingActor.FullName = actor.FullName;
            existingActor.ProfilePicUrl = actor.ProfilePicUrl;
            existingActor.Bio = actor.Bio;

            await _context.SaveChangesAsync();
            return existingActor;
        }

    }
}
