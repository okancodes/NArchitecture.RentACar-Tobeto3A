using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Cars.Queries.GetListDynamic;

public  class GetListCarDynamicQuery : IRequest<CarListModel>
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }
}

public class GetListCarDynamicQueryHandler : IRequestHandler<GetListCarDynamicQuery, CarListModel>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetListCarDynamicQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<CarListModel> Handle(GetListCarDynamicQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Car> cars = await _carRepository.GetListByDynamicAsync(request.Dynamic, index: request.PageRequest.Page,
            size: request.PageRequest.PageSize);
        CarListModel CarListModel = _mapper.Map<CarListModel>(cars);
        return CarListModel;
    }
}