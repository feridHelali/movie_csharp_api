using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.DTOs;
using Api.DTOs.MappingExtentions;
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

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            var movie = await _context.Movies
            .Include(m => m.Comments)
            .Include(m => m.MovieActor)
             .ThenInclude(ma => ma.Actor)
            .Include(m => m.Genres)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (movie is null)
            {
                return NotFound();
            }
            return Ok(movie);

        }

        [HttpGet]
        [Route("select/{id:int}")]
        public async Task<ActionResult> SelectLoading(int id)
        {
            var movie = await _context.Movies
              .Select(mo =>
                new
                {
                    Id = mo.Id,
                    Title = mo.Title,
                    Genres = mo.Genres.Select(g => g.Name).ToList(),
                    Actors = mo.MovieActor
                        .OrderBy(mo => mo.Order)
                        .Select(ma => new
                        {
                            Id = ma.ActorId,
                            ma.Actor.Name,
                            ma.Character,
                        }),
                    CommentsQuantity = mo.Comments.Count()
                }
              )
            .FirstOrDefaultAsync(m => m.Id == id);
            if (movie is null)
            {
                return NotFound();
            }
            return Ok(movie);

        }


        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddNewMovie([FromBody] MovieCreationDTO movieCreationDTO)
        {


            var movie = movieCreationDTO.MapToEntity();

            if (movie.Genres is not null)
            {
                foreach (var genre in movie.Genres)
                {
                    _context.Entry<Genre>(genre).State = EntityState.Unchanged;
                }
            }


            await _context.AddAsync(movie);

            await _context.SaveChangesAsync();

            return Ok();
        }

       
    }
}