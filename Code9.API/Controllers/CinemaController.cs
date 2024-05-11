using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Code9.Domain.Models;
using Code9.Domain.Queries;
using Code9.API.Models;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http.HttpResults;
using Code9.Domain.Commands;

namespace Code9.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CinemaController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cinema>>> GetAllCinema() {
            var query = new GetAllCinemaQuery();
            var cinema = await _mediator.Send(query);
            return Ok(cinema);
        }

        [HttpPost]
        public async Task<ActionResult<Cinema>> AddCinema(AddCinemaRequest cinemaRequest) {
            var addCinemaRequest = new AddCinemaCommand {
                Name = cinemaRequest.Name,
                City = cinemaRequest.City,
                Street = cinemaRequest.Street,
                NumberOfAuditoriums = cinemaRequest.NumberOfAuditoriums
            };


        var cinema = await _mediator.Send(addCinemaRequest);
        return CreatedAtAction(nameof(GetAllCinema), new {id = cinema.Id }, cinema);
        }
    }
}
