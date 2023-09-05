using System.Xml.Linq;
using System;
using Api.Entities;

namespace Api.DTOs.MappingExtentions
{
    public static class MovieMappingExtentions
    {
        public static Movie MapToEntity(this MovieCreationDTO dto)
        {
            var movie = new Movie
            {
                Title = dto.Title,
                InTheater = dto.InTheater,
                ReleaseDate = dto.ReleaseDate,
                Genres = dto.Genres.Select(genreId => new Genre { Identifier = genreId }).ToHashSet<Genre>(),
                MovieActor = dto.MovieActors
                    .Select(actorDto => new MovieActor
                    {
                        ActorId = actorDto.ActorId,
                        Character = actorDto.Character,
                    }).ToList()
            };



            if (movie.MovieActor is not null)
            {
                for (int i = 0; i < movie.MovieActor.Count; i++)
                {
                    movie.MovieActor[i].Order = i + 1;
                }

                foreach (var movieActor in movie.MovieActor)
                {
                    movieActor.Movie = movie;
                }
            }

            return movie;
          
        }
    }
}