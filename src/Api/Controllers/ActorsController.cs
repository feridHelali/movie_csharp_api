using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.DTOs;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ActorsController : Controller
    {
        private readonly ILogger<ActorsController> _logger;
        private readonly ApplicationDbContext _context;

        public ActorsController(ILogger<ActorsController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }



        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult<Actor>> GetByName(string name)
        {
            var actor = await _context.Actors.Where(ac => ac.Name == name).FirstOrDefaultAsync();
            if (actor is null)
            {
                return NotFound();
            }
            return Ok(actor);
        }

        [HttpGet]
        [Route("{name}/v2")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetByNamePortion(string name)
        {
            var actors = await _context.Actors
                .Where(ac => ac.Name.Contains(name))
                .OrderBy(ac => ac.Name)
                 .ThenBy(ac => ac.DateOfBirth)
                 .ToListAsync<Actor>();
            if (actors is null)
            {
                return NotFound();
            }
            return Ok(actors);
        }


        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<IEnumerable<Actor>>> GetAllActors()
        {
            return await _context.Actors.ToListAsync<Actor>();
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Actor>> GetActorById(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(ac=>ac.Id==id);
            if (actor is null)
            {
                return NotFound();
            }
            return Ok(actor);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddNewActor([FromBody] ActorCreationDTO request)
        {
            var newActore = new Actor() { Name = request.Name, Fortune = request.Fortune, DateOfBirth = request.DateOfBirth };
            await _context.Actors.AddAsync(newActore);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActorById), new { Id = newActore.Id }, newActore);
        }


    }
}