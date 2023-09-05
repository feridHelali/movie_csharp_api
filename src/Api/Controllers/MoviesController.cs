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

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddNewMovie([FromBody] MovieCreationDTO movieCreationDTO)
        {


            var movie = movieCreationDTO.MapToEntity();
            
            if(movie.Genres is not null)
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