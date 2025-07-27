using eTickets.Data.Enums;
using eTickets.Models;
using Microsoft.IdentityModel.Tokens;
using System.Net.NetworkInformation;

namespace eTickets.Data
{
    public class AppDbInitializer
    {

        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();  // Creating an instance to invoke the AppDbContext to interact with my Database

                context.Database.EnsureCreated(); // just Ensuring that our database is created

                //Cinema

                if (!context.Cinemas.Any())
                {

                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                    });
                    context.SaveChanges();

                }


                //Producer


                if (!context.Producers.Any())
                {

                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            
                            fullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            profilepicUrl = "/Images/producer_1_image.jpg"

                        },
                        new Producer()
                        {
                            
                            fullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            profilepicUrl = "/Images/producer_2_image.jpg"
                        },
                        new Producer()
                        { 
                            
                            fullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            profilepicUrl = "/Images/producer_3_image.jpg"
                        },
                        new Producer()
                        {
                            
                            fullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            profilepicUrl ="/Images/producer_4_image.jpg"
                        },
                        new Producer()
                        {
                           
                            fullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            profilepicUrl = "/Images/producer_5_image.jpeg"
                        }
                    });
                    context.SaveChanges();
                }




                //Actor

                if (!context.Actors.Any())
                {

                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePicUrl = "/Images/actor_1_image.jpeg"

                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                             ProfilePicUrl = "/Images/actor_2_image.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the third actor",
                            ProfilePicUrl = "/Images/actor_3_image.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the Fourth actor",
                            ProfilePicUrl = "/Images/actor_4_image.webp"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the Fifth actor",
                            ProfilePicUrl = "/Images/actor_5_image.webp"
                        }
                    });
                    context.SaveChanges();

                }




                if (!context.Movies.Any())
                {
                    // Fetch Producers and Cinemas by Name (not by ID)
                    var producer1 = context.Producers.FirstOrDefault(p => p.fullName == "Producer 1");
                    var producer2 = context.Producers.FirstOrDefault(p => p.fullName == "Producer 2");
                    var producer3 = context.Producers.FirstOrDefault(p => p.fullName == "Producer 3");

                    var producer5 = context.Producers.FirstOrDefault(p => p.fullName == "Producer 5");

                    var cinema1 = context.Cinemas.FirstOrDefault(c => c.Name == "Cinema 1");
                    var cinema3 = context.Cinemas.FirstOrDefault(c => c.Name == "Cinema 3");
                    var cinema4 = context.Cinemas.FirstOrDefault(c => c.Name == "Cinema 4");

                    if (producer1 == null || producer2 == null || producer3 == null ||  producer5 == null ||
                        cinema1 == null || cinema3 == null || cinema4 == null)
                    {
                        throw new Exception("Required Producers or Cinemas not found. Seeding failed.");
                    }

                    var movies = new List<Movies>()
    {
        new Movies()
        {
            Name = "Life",
            Description = "This is the Life movie description",
            Price = 39.50,
            ImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
            StartDate = DateTime.Now.AddDays(-10),
            EndDate = DateTime.Now.AddDays(10),
            CinemaId = cinema3.Id,
            ProducerId = producer3.Id,
            MovieCategory = MovieCategory.Documentary
        },
        new Movies()
        {
            Name = "The Shawshank Redemption",
            Description = "This is the Shawshank Redemption description",
            Price = 29.50,
            ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(3),
            CinemaId = cinema1.Id,
            ProducerId = producer1.Id,
            MovieCategory = MovieCategory.Action
        },
        new Movies()
        {
            Name = "Ghost",
            Description = "This is the Ghost movie description",
            Price = 39.50,
            ImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddDays(7),
            CinemaId = cinema4.Id,
            ProducerId = producer2.Id,
            MovieCategory = MovieCategory.Horror
        },
        new Movies()
        {
            Name = "Race",
            Description = "This is the Race movie description",
            Price = 39.50,
            ImageUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
            StartDate = DateTime.Now.AddDays(-10),
            EndDate = DateTime.Now.AddDays(-5),
            CinemaId = cinema1.Id,
            ProducerId = producer2.Id,
            MovieCategory = MovieCategory.Documentary
        },
        new Movies()
        {
            Name = "Scoob",
            Description = "This is the Scoob movie description",
            Price = 39.50,
            ImageUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
            StartDate = DateTime.Now.AddDays(-10),
            EndDate = DateTime.Now.AddDays(-2),
            CinemaId = cinema1.Id,
            ProducerId = producer3.Id,
            MovieCategory = MovieCategory.Cartoon
        },
        new Movies()
        {
            Name = "Cold Soles",
            Description = "This is the Cold Soles movie description",
            Price = 39.50,
            ImageUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
            StartDate = DateTime.Now.AddDays(3),
            EndDate = DateTime.Now.AddDays(20),
            CinemaId = cinema1.Id,
            ProducerId = producer5.Id,
            MovieCategory = MovieCategory.Drama
        }
    };

                    context.Movies.AddRange(movies);
                    context.SaveChanges();

                    // Save actual movie references
                    var movie1 = movies[0];
                    var movie2 = movies[1];
                    var movie3 = movies[2];
                    var movie4 = movies[3];
                    var movie5 = movies[4];
                    var movie6 = movies[5];

                    // Get Actors dynamically
                    var actors = context.Actors.ToList();
                    var actor1 = actors.FirstOrDefault(a => a.FullName == "Actor 1");
                    var actor2 = actors.FirstOrDefault(a => a.FullName == "Actor 2");
                    var actor3 = actors.FirstOrDefault(a => a.FullName == "Actor 3");
                    var actor4 = actors.FirstOrDefault(a => a.FullName == "Actor 4");
                    var actor5 = actors.FirstOrDefault(a => a.FullName == "Actor 5");

                    if (actor1 != null && actor2 != null && actor3 != null && actor4 != null && actor5 != null)
                    {
                        if (!context.Actors_Movies.Any())
                        {
                            context.Actors_Movies.AddRange(new List<Actor_Movie>()
            {
                new Actor_Movie() { ActorId = actor1.Id, MovieId = movie1.Id },
                new Actor_Movie() { ActorId = actor3.Id, MovieId = movie1.Id },

                new Actor_Movie() { ActorId = actor1.Id, MovieId = movie2.Id },
                new Actor_Movie() { ActorId = actor4.Id, MovieId = movie2.Id },

                new Actor_Movie() { ActorId = actor1.Id, MovieId = movie3.Id },
                new Actor_Movie() { ActorId = actor2.Id, MovieId = movie3.Id },
                new Actor_Movie() { ActorId = actor5.Id, MovieId = movie3.Id },

                new Actor_Movie() { ActorId = actor2.Id, MovieId = movie4.Id },
                new Actor_Movie() { ActorId = actor3.Id, MovieId = movie4.Id },
                new Actor_Movie() { ActorId = actor4.Id, MovieId = movie4.Id },

                new Actor_Movie() { ActorId = actor2.Id, MovieId = movie5.Id },
                new Actor_Movie() { ActorId = actor3.Id, MovieId = movie5.Id },
                new Actor_Movie() { ActorId = actor4.Id, MovieId = movie5.Id },
                new Actor_Movie() { ActorId = actor5.Id, MovieId = movie5.Id },

                new Actor_Movie() { ActorId = actor3.Id, MovieId = movie6.Id },
                new Actor_Movie() { ActorId = actor4.Id, MovieId = movie6.Id },
                new Actor_Movie() { ActorId = actor5.Id, MovieId = movie6.Id },
            });

                            context.SaveChanges();
                        }
                    }
                    else
                    {
                        throw new Exception("One or more Actors not found in database. Actor_Movie seeding failed.");
                    }
                }









            }
        }
    }
}
