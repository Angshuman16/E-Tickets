using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace eTickets.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext>options) :base(options)
        {

            
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });


            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);


          


        }


        public DbSet<Actor> Actors { get; set; }


        public DbSet<Movies> Movies { get; set; }



        public DbSet<Actor_Movie> Actors_Movies { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }


        //Data Source=.;Initial Catalog=ecommerce-app-db;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True

        public DbSet<Producer> Producers { get; set; }








    }
}
