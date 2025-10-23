using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAllActors();


       Task<Actor> GetByIdAsync(int id);


        void Add(Actor actor);


        Task<Actor> UpdateAsync(int id, Actor actor);


        Task DeleteAsync(int id);

    }
}
