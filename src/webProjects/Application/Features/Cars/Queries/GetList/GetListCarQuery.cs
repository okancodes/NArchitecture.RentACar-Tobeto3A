using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Queries.GetList;

public class GetListCarQuery : IRequest<List<GetListedCarResponse>>
{


    public class GetListCarQueryHandler : IRequestHandler<GetListCarQuery, List<GetListedCarResponse>>
    {
        private readonly ICarRepository _CarRepository;
        private readonly IMapper _mapper;

        public GetListCarQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _CarRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListedCarResponse>> Handle(GetListCarQuery request, CancellationToken cancellationToken)
        {
            List<Car> car = await _CarRepository.GetAllAsync();
            List<GetListedCarResponse> response = _mapper.Map<List<GetListedCarResponse>>(car);
            return response;
        }
    }
}
