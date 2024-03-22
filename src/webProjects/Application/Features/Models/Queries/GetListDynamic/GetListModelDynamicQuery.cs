using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Request;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Queries.GetListDynamic;

public class GetListModelDynamicQuery : IRequest<ModelListModel>
{
    public PageRequest PageRequest { get; set; }
    public Dynamic Dynamic { get; set; }
}

public class GetListModelDynamicQueryHandler : IRequestHandler<GetListModelDynamicQuery, ModelListModel>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListModelDynamicQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<ModelListModel> Handle(GetListModelDynamicQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Model> models = await _modelRepository.GetListByDynamicAsync(request.Dynamic, index: request.PageRequest.Page,
            size: request.PageRequest.PageSize);
        ModelListModel ModelListModel = _mapper.Map<ModelListModel>(models);
        return ModelListModel;
    }
}