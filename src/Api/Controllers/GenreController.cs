using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Entities;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Api.DTOs;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenreController : Controller
    {
        private readonly ILogger<GenreController> _logger;
        private readonly ApplicationDbContext _context;

        public GenreController(ILogger<GenreController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddNewGenre([FromBody] GenreCreationDTO request)
        {
            var genre = new Genre() { Name = request.Name };
            await _context.Set<Genre>().AddAsync(genre);
            await _context.SaveChangesAsync();
            return Ok(genre);
        }

        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<Genre>>> GetAllGenres()
        {
            var result = await _context.Genres.ToListAsync();
            return Ok(result);
        }


        /// <summary>
        /// Use Connected Model to update entity/table
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> UpateConnectedModel(int id,string name)
        {
            var genre=await _context.Genres.FirstOrDefaultAsync(g=>g.Identifier==id);
            if(genre is null)
            {
                return NotFound();
            }
            genre.Name=name;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("{id:int}/name")]
        public async Task<ActionResult> UpateDisconnectedModel(int id,string name)
        {
            var genre=new Genre{Identifier=id,Name=name};
            _context.Update(genre);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}