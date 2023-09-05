using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.DTOs;
using Api.DTOs.MappingExtentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/Movies/{movieId:int}/comments")]
    public class CommentController : Controller
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ApplicationDbContext _context;

        public CommentController(ILogger<CommentController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddCommentToMovie([FromBody]CommentCreationDTO request,[FromRoute] int movieId)
        {
            var comment = request.MapToEntity();
            comment.MovieId = movieId;
            _context.Add(comment);
            await _context.SaveChangesAsync();
            return Ok("Comment Added Successfully");
        }

       
    }
}