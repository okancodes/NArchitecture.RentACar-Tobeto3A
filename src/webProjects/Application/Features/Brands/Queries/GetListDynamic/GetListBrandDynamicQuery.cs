using Application.Features.Brands.Models;
using Core.Application.Pipelines.Caching;
using Core.Application.Request;
using Core.Persistence.Dynamic;
using MediatR;

namespace Application.Features.Brands.Queries.GetListDynamic;

public class GetListBrandDynamicQuery : IRequest<BrandListModel>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }

    public bool BypassCache { get; }

    public string CacheKey => "brand-list";

    public TimeSpan? SlidingExpiration { get; }
}
