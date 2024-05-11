using Code9.Domain.Interfaces;
using Code9.Domain.Queries;
using System;
using MediatR;
using Code9.Domain.Models;

namespace Code9.Domain.Handlers
{
    public class GetAllCinemasQueryHandler : IRequestHandler<GetAllCinemaQuery, List<Cinema>> {
        private readonly ICinemaRepository _cinemaRepository;

        public GetAllCinemasQueryHandler(ICinemaRepository cinemaRepository) {
            _cinemaRepository = cinemaRepository;
        }

        public async Task<List<Cinema>> Handle(GetAllCinemaQuery request, CancellationToken cancellationToken)
        {
            return await _cinemaRepository.GetAllCinemas();
        }
    }
}
