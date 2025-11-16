using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movies>, IMoviesService
    {


        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context) :base(context)
        {


            _context = context;

        }

       async Task<Movies> IMoviesService.GetMovieByIdAsync(int id)
        {


            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);




             return  movieDetails;
        }
    }
}
