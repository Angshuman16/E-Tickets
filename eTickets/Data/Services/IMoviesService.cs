using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movies>
    {

        // Implementing a custom function for the Movies:

        Task<Movies> GetMovieByIdAsync (int id);
    }
}
