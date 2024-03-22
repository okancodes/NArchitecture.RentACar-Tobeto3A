using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandQuery : IRequest<List<GetListedBrandResponse>>, ICachableRequest
{
    public bool BypassCache  {get;}
    public string CacheKey => "brand-list";
    public TimeSpan? SlidingExpiration { get;}

    public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, List<GetListedBrandResponse>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetListBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<List<GetListedBrandResponse>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
            List<Brand> brand = await _brandRepository.GetAllAsync();
            List<GetListedBrandResponse> response = _mapper.Map<List<GetListedBrandResponse>>(brand);
            return response;
        }
    }
}
