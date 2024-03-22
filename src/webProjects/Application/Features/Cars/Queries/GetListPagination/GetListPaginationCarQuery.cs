using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Request;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Queries.GetListPagination;

public class GetListPaginationCarQuery : IRequest<CarListModel>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public bool BypassCache { get; }

    public string CacheKey => "brand-list";

    public TimeSpan? SlidingExpiration { get; }
}

public class GetListPaginationCarQueryHandler : IRequestHandler<GetListPaginationCarQuery, CarListModel>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetListPaginationCarQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<CarListModel> Handle(GetListPaginationCarQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Car> cars = await _carRepository.GetListPaginateAsync
            (index: request.PageRequest.Page, size: request.PageRequest.PageSize);
        CarListModel CarListModel = _mapper.Map<CarListModel>(cars);
        return CarListModel;
    }
}