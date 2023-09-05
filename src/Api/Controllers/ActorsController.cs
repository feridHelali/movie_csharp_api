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

        public ActorsController(ILogger<ActorsController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context =context;
        }

        [HttpGet]
        [Route("All")]
         public async Task<ActionResult<IEnumerable<Actor>>> Get()
         {
            return await _context.Actors.ToListAsync<Actor>();
         }
        
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddNewActor([FromBody] ActorCreationDTO request)
        {
            var newActore=new Actor(){Name=request.Name,Fortune=request.Fortune,DateOfBirth=request.DateOfBirth};
            await _context.Actors.AddAsync(newActore);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetActor), new {Id=newActore.Id},newActore);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Actor> GetActor(int id)
         {
            var actor = _context.Actors.Where<Actor>(ac=>ac.Id==id).FirstOrDefault();
            if(actor == null)
            {
                return NotFound("This Actor is Not Found");
            }
            else
            {
                return Ok(actor);
            }
         }
    }
}