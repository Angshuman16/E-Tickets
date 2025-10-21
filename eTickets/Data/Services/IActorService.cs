using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAllActors();


       Task<Actor> GetByIdAsync(int id);


        void Add(Actor actor);


        Actor Update(int id, Actor actor);


        void Delete(int id);

    }
}
