using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.DTOs;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly ApplicationDbContext _context;

        public MoviesController(ILogger<MoviesController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddNewMovie([FromBody] MovieCreationDTO movieCreationDTO)
        {


            Movie movie = new Movie()
            {
                Title = movieCreationDTO.Title,
                InTheater = movieCreationDTO.InTheater,
                ReleaseDate = movieCreationDTO.ReleaseDate,
                Genres = movieCreationDTO.Genres.Select(id => new Genre() { Identifier = id }).ToHashSet<Genre>(),
                MovieActor = movieCreationDTO.MovieActors
                    .Select(
                        ma => new MovieActor()
                        {   
                            ActorId = ma.ActorId,
                            Character = ma.Character
                        }).ToList<MovieActor>(),
            };



            if (movie.Genres is not null)
            {
                foreach (var genre in movie.Genres)
                {
                    _context.Entry(genre).State = EntityState.Unchanged;
                }
            }

            if (movie.MovieActor is not null)
            {
                for (int i = 0; i < movie.MovieActor.Count; i++)
                {
                    movie.MovieActor[i].Order = i + 1;
                }

                foreach (var actor in movie.MovieActor)
                {
                    _context.Entry(actor).State = EntityState.Unchanged;
                }

                foreach (var movieActor in movie.MovieActor)
                {
                    movieActor.MovieId = movie.Id;
                }
            }


            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}