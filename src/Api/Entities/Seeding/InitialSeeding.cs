using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.Seeding
{
    public class InitialSeeding 
    {
       public static void Seeding(ModelBuilder builder)
       {
            var samuelJakson = new Actor
            {
                Id = 3,
                Name = "Sauel JAKSON",
                DateOfBirth = new DateTime(1944, 1, 1),
                Fortune = 4585200
            };

            var juliaRoberts = new Actor
            {
                Id = 4,
                Name = "Julia ROBERTS",
                DateOfBirth = new DateTime(1971, 5, 4),
                Fortune = 7985200
            };
            builder.Entity<Actor>().HasData(samuelJakson, juliaRoberts);

            var evenger = new Movie {
                Id = 3,
                Title = "The Evengers",
                ReleaseDate = new DateTime(2020, 12, 31),
            };
            var braveHart = new Movie { 
                Id = 4,
                Title = "Brave Hart",
                ReleaseDate = new DateTime(2001, 08, 5),
            };
            builder.Entity<Movie>().HasData(evenger, braveHart);


            var avengerComment = new Comment {
                Id = 6,
                Content = "The suspense till the End",
                Recommend = true,
                MovieId=evenger.Id,
            };

            builder.Entity<Comment>().HasData(avengerComment);

            var tableGenreMovie = "GenreMovie";
            var genreIdProperty = "GenresIdentifier";
            var movieIdProperty = "MoviesId";

            var comedy = 3;


            builder.Entity(tableGenreMovie ).HasData(
                new Dictionary<string,object>{
                    [genreIdProperty]=comedy,
                    [movieIdProperty]=evenger.Id,
                }
            );

            var samuelBraveheart = new MovieActor
            {
                ActorId = samuelJakson.Id,
                MovieId = braveHart.Id,
                Order = 1,
                Character = "The King"
            };

            builder.Entity<MovieActor>().HasData(samuelBraveheart);
       }
    }
}